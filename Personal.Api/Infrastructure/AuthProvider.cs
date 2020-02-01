using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Personal.Domain;
using Personal.Domain.Models;

namespace Personal.Infrastructure
{
    public static class AuthProvider
    {
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfigurationRoot appSettings)
        {
            services.AddIdentity<ApplicationIdentityUser, ApplicationIdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 2;

                options.Lockout = new LockoutOptions()
                {
                    AllowedForNewUsers = true,
                    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                    MaxFailedAccessAttempts = 3,
                };
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
            

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Login";
//                opt.LogoutPath = "/Login/Logout";
//                opt.AccessDeniedPath = "/AccessDenied";
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(int.Parse(
                    string.IsNullOrWhiteSpace(appSettings["expireTimeSpan"])
                        ? "30"
                        : appSettings["expireTimeSpan"]));
                opt.SlidingExpiration = true;
            });

            return services;
        }
    }
}