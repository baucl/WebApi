using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Domain.Interfaces;

namespace WebApi.Infrastructure.DataAccess
{
    public class AuthenticateRepository: IAuthenticateRepository
    {
        private readonly IConfiguration _configuration;
        public AuthenticateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateSecurityToken(string userName)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                   new Claim(ClaimTypes.Surname, userName),
            };

            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
               _configuration.GetSection("TokenAuthentication:Issuer").Key,
               _configuration.GetSection("TokenAuthentication:Audience").Key,
               claims,
               expires: DateTime.Now.AddDays(1),
               signingCredentials: creds
               ));
        }
    }
}
