using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.NameTranslation;
using StructureMap;

namespace Personal.Domain
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            Scan(_ =>
            {
                _.AssemblyContainingType<StructureMapRegistry>();
                _.LookForRegistries();
            });
            // Register the Ef DataContext as scoped (ie: one per HttpRequest)
            ForConcreteType<DataContext>().Configure.ContainerScoped();

            // The actual database table/column names use "snake_casing".
            For<INpgsqlNameTranslator>().Use<NpgsqlSnakeCaseNameTranslator>();

            // Our custom Materializer, this is the closest we
            // will get to EF6's ObjectMaterialized event.
            // see: https://github.com/aspnet/EntityFramework/issues/626
            For<IEntityMaterializerSource>().Use<EntityMaterializerSource>();

            // Build the options for the DataContext
            For<DbContextOptions<DataContext>>().Use("DbContextOptionsBuilder", container =>
            {
                var builder = new DbContextOptionsBuilder<DataContext>();
                var appSettings = container.TryGetInstance<IConfigurationRoot>();

                // Build our own service container for Ef.
                var efServices = new ServiceCollection();

                if (appSettings != null)
                {
                    var cs = appSettings["ConnectionStrings:(default)"];
                    if (string.IsNullOrWhiteSpace(cs)) cs = ".";
                    builder.UseNpgsql(cs, o => o.UseNetTopologySuite());
                }

                // Now add all the other primary ef services.
                // It is important this comes after our custom service
                // definitions as the primary services are only added if
                // the a custom definition does not exist.
                efServices.AddEntityFrameworkNpgsql();
                efServices.AddEntityFrameworkNpgsqlNetTopologySuite();

                // Finally tell the DbContextOptionsBuilder to use our custom container
                builder.UseInternalServiceProvider(efServices.BuildServiceProvider());

                return builder.Options;
            });
        }
    }
}