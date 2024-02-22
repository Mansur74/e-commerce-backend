using Business.Abstracts;
using Entities.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class TokenManager : ITokenService
    {
        public readonly IConfiguration _configuration;

        public TokenManager(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string GenerateAccessToken(User user, List<Claim> claims)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AccessToken:Secret"]));
            _ = int.TryParse(_configuration["JWT:AccessToken:ValidityInSeconds"], out int tokenValidityInSeconds);

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddSeconds(tokenValidityInSeconds),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateRefreshToken(User user, List<Claim> claims)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:RefreshToken:Secret"]));

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    claims: claims,
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string ValidateRefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:RefreshToken:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out validatedToken);


            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                string email = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                return email;

            }

            else
            {
                throw new Exception("Refresh token is not valid");
            }

        }
    }
}
