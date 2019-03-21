using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace Personal.Domain
{
    public static class ConfigurationProvider
    {

        public static IServiceCollection Configure(
            this IServiceCollection services,
            IConfigurationRoot appSettings,
            IWebHostBuilder webHostBuilder
        )
        {
            services.AddSingleton<IConfigurationRoot>(appSettings);
            services.AddSingleton<IWebHostBuilder>(webHostBuilder);
            return services;
        }
    }
}