using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StructureMap;

namespace Personal.Domain
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public IContainer Container { get; set; }
        
        public DataContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrWhiteSpace(env)) env = "Development";
            
            var basePath = System.AppContext.BaseDirectory;
            if (!File.Exists($"{basePath}appsettings.json"))
            {
                basePath = basePath + "../../../";

                if (!File.Exists($"{basePath}appsettings.json"))
                {
                    basePath = basePath + "../Personal.Domain";
                }
            }
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath);
            
            configBuilder = configBuilder
                .AddJsonFile("appsettings.json", optional: true);

            var appSettings = configBuilder.Build();
            
            Container = new Container(new StructureMapRegistry());
            Container.Configure(_ =>
            {
                _.For<IConfigurationRoot>().Use(appSettings).Singleton();
            });
            return Container.GetInstance<DataContext>();
        }
    }
}