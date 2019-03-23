using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using Personal.Domain.Models;
using StructureMap;

namespace Personal.Domain
{     
    public class DataContext : IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, Guid>
    {      
        public virtual DbSet<JobPosition> JobPositions { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }

        private readonly string _customConnection;
        private readonly IContainer _services;
        private readonly INpgsqlNameTranslator _nameTranslator;


        public DataContext(
            DbContextOptions<DataContext> options,
            IContainer services,
            INpgsqlNameTranslator nameTranslator,
            string customConnection = "")
            : base(options)
        {
            _services = services;
            _nameTranslator = nameTranslator;
            _customConnection = customConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_customConnection))
            {
                optionsBuilder.UseNpgsql(_customConnection, o => o.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddModelEntities(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                this.MapTableNames(entity);
                this.ConfigureInlineJsonColumns(modelBuilder, entity);

                foreach (var property in entity.GetProperties())
                {
                    ConfigureCiText(modelBuilder, property);
                    MapColumnNames(property);
                }
            }
        }

        private static void AddModelEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionTechnology>().HasKey(_ => new { _.PositionId, _.TechnologyId });
            modelBuilder.Entity<JobPosition>();
            modelBuilder.Entity<Technology>();
            modelBuilder.Entity<ApplicationIdentityUser>();
        }

        private void MapColumnNames(IMutableProperty property)
        {
            var columnName = property.Relational().ColumnName;
            property.Relational().ColumnName = _nameTranslator.TranslateMemberName(columnName);
        }

        private void MapTableNames(IMutableEntityType entity)
        {
            entity.Relational().TableName =
                "t_" + _nameTranslator.TranslateMemberName(entity.Relational().TableName);
        }

        private void ConfigureCiText(ModelBuilder modelBuilder, IMutableProperty property)
        {
            modelBuilder.HasPostgresExtension("citext");

            if (property.PropertyInfo?.PropertyType == typeof(string))
            {
                var columnAttribute = property.PropertyInfo
                    .GetCustomAttributes<ColumnAttribute>()
                    .SingleOrDefault();
                
                if (string.IsNullOrEmpty(columnAttribute?.TypeName))
                {
                    property.Relational().ColumnType = "citext";
                }
            }
        }
        
        private Dictionary<Type, Dictionary<PropertyInfo, string>> inlineJsonProps
            = new Dictionary<Type, Dictionary<PropertyInfo, string>>();

        private void ConfigureInlineJsonColumns(ModelBuilder modelBuilder, IMutableEntityType entity)
        {
            var jsonInlineProps = entity.ClrType.GetProperties()
                .Where(_ => _.GetCustomAttributes<InlineJsonAttribute>().Any())
                .ToList();

            if (jsonInlineProps.Count > 0)
            {
                this.inlineJsonProps[entity.ClrType]
                    = new Dictionary<PropertyInfo, string>();
            }

            foreach (var prop in jsonInlineProps)
            {
                // Create the shadow property name
                var shadowPropName = _nameTranslator.TranslateMemberName($"{prop.Name}Json");

                // Save it for later use in `SerialiseInlineJson`
                this.inlineJsonProps[entity.ClrType].Add(prop, shadowPropName);

                // Ensure any properties marked with InlineJson are not automatically mapped.
                modelBuilder.Entity(entity.ClrType).Ignore(prop.Name);

                // Now lets create a shadow property for the JSONB Column
                modelBuilder.Entity(entity.ClrType)
                    .Property(typeof(string), shadowPropName)
                    .HasColumnType("jsonb");
            }
        }
    } 
}