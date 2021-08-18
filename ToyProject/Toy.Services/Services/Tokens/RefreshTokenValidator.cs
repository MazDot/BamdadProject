using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Toy.Entities;

namespace Toy.Services.Services.Tokens
{
    public class RefreshTokenValidator
    {
        private readonly AuthenticationConfiguration config;

        public RefreshTokenValidator(AuthenticationConfiguration config)
        {
            this.config = config;
        }

        public bool ValidateRefreshToken(string refreshToken)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.RefreshTokenSecret)),
                ValidIssuer = config.Issuer,
                ValidAudience = config.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
