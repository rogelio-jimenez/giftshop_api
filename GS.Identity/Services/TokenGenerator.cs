using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GS.Identity.Services
{
    public class TokenGenerator
    {
        public JwtSecurityToken JwtSecurityToken { get; set; }
        public string GenerateToken(string secretKey, string issuer, string audience, int expirationTime, IEnumerable<Claim> claims = null)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(expirationTime),
                signingCredentials: signingCredentials);

            JwtSecurityToken = jwtSecurityToken;

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}