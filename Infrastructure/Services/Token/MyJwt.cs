using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Services.Token;
using Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.Jwt
{
    public class MyJwt : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public MyJwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string idUser, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, idUser),
                new Claim(ClaimTypes.Role, role),
            };

            var secret = _configuration.GetValue<string>("Jwt:Key");
            var key = new SymmetricSecurityKey(Encoding.Default.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: null, //"https://localhost:7155/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
