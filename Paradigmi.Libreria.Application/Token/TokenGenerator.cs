using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Models.Entities;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Paradigmi.Libreria.Application.Options;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Paradigmi.Libreria.Application.Token
{
    public class TokenGenerator
    {
        private readonly JwtAuthenticationOption _jwtOptions;

        public TokenGenerator(IOptions<JwtAuthenticationOption> jwtAuthOps)
        {
            _jwtOptions = jwtAuthOps.Value;
        }
        public string CreateToken(Utente utente)
        {
            var claims = new List<Claim>
            {
                new Claim("IdUtente", utente.IdUtente.ToString()),
                new Claim(ClaimTypes.Email, utente.Email),
                new Claim(ClaimTypes.Name, utente.Nome)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtOptions.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
