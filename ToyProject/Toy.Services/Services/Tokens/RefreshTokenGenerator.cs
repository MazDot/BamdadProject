using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Toy.Entities;

namespace Toy.Services.Services.Tokens
{
    public class RefreshTokenGenerator
    {
        private readonly AuthenticationConfiguration config;
        private readonly TokenGenerator tokenGenerator;

        public RefreshTokenGenerator(AuthenticationConfiguration config, TokenGenerator tokenGenerator)
        {
            this.config = config;
            this.tokenGenerator = tokenGenerator;
        }

        public string GenerateToken()
        {
            return tokenGenerator.GenerateToken(config.RefreshTokenSecret, config.Issuer, config.Audience, config.RefreshExpirationDays);

        }

    }
}
