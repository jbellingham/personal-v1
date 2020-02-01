using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Personal.Infrastructure;
using StructureMap;
using ConfigurationProvider = Personal.Infrastructure.ConfigurationProvider;

namespace Personal
{
    public class Startup
    { 
        public IConfigurationRoot AppSettings { get; set; }
        public static IWebHostBuilder WebHostBuilder { get; set; }
        public IWebHostEnvironment Environment { get; set; }
        
        public Startup(IWebHostEnvironment environment)
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
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>();
            
            WebHostBuilder.Build().Run();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            ConfigurationProvider.Configure(services, this.AppSettings, WebHostBuilder);
            services.AddAuth(this.AppSettings);
            
//            services.AddIdentity<ApplicationIdentityUser, ApplicationIdentityRole>()
//                .AddEntityFrameworkStores<DataContext>()
//                .AddDefaultTokenProviders();

            services.AddRouting();
            services.AddControllers();
            services.AddSwaggerGen(_ => 
            {
                _.SwaggerDoc("v1", new OpenApiInfo { Title = "Personal.Api", Version = "v1" });
            });
            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    
                });
                // .AddJwtBearer(cfg =>
                // {
                //     cfg.RequireHttpsMetadata = false;
                //     cfg.SaveToken = true;
                //     cfg.TokenValidationParameters = new TokenValidationParameters
                //     {
                //         ValidIssuer = this.AppSettings["JwtIssuer"],
                //         ValidAudience = this.AppSettings["JwtIssuer"],
                //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.AppSettings["JwtKey"])),
                //         ClockSkew = TimeSpan.Zero // remove delay of token when expire
                //     };
                // });
            
            services.AddAutoMapper();

            var container = new Container(new StructureMapRegistry());
            container.Populate(services);
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(_ =>
            {
                _.SwaggerEndpoint("/swagger/v1/swagger.json", "Personal.Api");
            });

            var configBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);
            if (File.Exists(Path.Join(env.ContentRootPath, "appsettings.json")))
            {
                configBuilder = configBuilder
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
            }

            app.UseRouting();
            app.UseEndpoints(_ =>
            {
                _.MapControllers();
            });

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

            app.UseAuthentication();
        }
    }
}