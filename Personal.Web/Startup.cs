using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Personal.Infrastructure;
using StructureMap;
using ConfigurationProvider = Personal.Infrastructure.ConfigurationProvider;

namespace Personal
{
    public class Startup
    { 
        public IConfigurationRoot AppSettings { get; set; }
        public static IWebHostBuilder WebHostBuilder { get; set; }
        public IHostingEnvironment Environment { get; set; }
        
        public Startup(IHostingEnvironment environment)
        {
            this.Environment = environment;
            var configBuilder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath);
            if (File.Exists(Path.Join(environment.ContentRootPath, "appsettings.json")))
            {
                configBuilder = configBuilder
                    .AddJsonFile("appsettings.json", optional: false);
            }

            this.AppSettings = configBuilder.Build();
        }
        
        
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables("ASPNETCORE_")
                .AddCommandLine(args)
                .Build();

            WebHostBuilder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>();
            
            WebHostBuilder.Build().Run();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure(this.AppSettings, WebHostBuilder);
            
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            var container = new Container(new StructureMapRegistry());
            container.Populate(services);
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);
            if (File.Exists(Path.Join(env.ContentRootPath, "appsettings.json")))
            {
                configBuilder = configBuilder
                    .AddJsonFile("appsettings.json", optional: false);
            }

            this.AppSettings = configBuilder.Build();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "api",
                        template: "api/{controller}/{action=Index}");
                    
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                });

            app.UseSpa(
                spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseReactDevelopmentServer(npmScript: "start");
                    }
                });
        }
    }
}