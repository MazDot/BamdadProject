using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Toy.Entities;

namespace Toy.Services.Services.Tokens
{
    public class AccessTokenGenerator
    {
        private readonly AuthenticationConfiguration config;
        private readonly TokenGenerator tokenGenerator;

        public AccessTokenGenerator(AuthenticationConfiguration config, TokenGenerator tokenGenerator)
        {
            this.config = config;
            this.tokenGenerator = tokenGenerator;
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
            return tokenGenerator.GenerateToken(config.Secret, config.Issuer, config.Audience, config.ExpirationDays, claims);

        }

    }
}
