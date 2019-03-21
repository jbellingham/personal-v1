using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Personal.Infrastructure
{
    public static class ConfigurationProvider
    {
        public static IServiceCollection Configure(
            this IServiceCollection services,
            IConfigurationRoot appSettings,
            IWebHostBuilder webHostBuilder)
        {
            Domain.ConfigurationProvider.Configure(services, appSettings, webHostBuilder);
            return services;
        }
    }
}