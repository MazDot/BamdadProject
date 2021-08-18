using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class AuthenticationConfiguration
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationDays { get; set; }
        public string RefreshTokenSecret { get; set; }
        public int RefreshExpirationDays { get; set; }
    }
}
