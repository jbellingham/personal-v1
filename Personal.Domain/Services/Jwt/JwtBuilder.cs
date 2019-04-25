using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Personal.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Personal.Domain.Services.Jwt
{
    public class JwtBuilder : IJwtBuilder
    {
        private readonly IConfigurationRoot _appSettings;
        
        public JwtBuilder(IConfigurationRoot appSettings)
        {
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
        }
        
        public string GenerateJwtToken(string email, ApplicationIdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_appSettings["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _appSettings["JwtIssuer"],
                _appSettings["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}