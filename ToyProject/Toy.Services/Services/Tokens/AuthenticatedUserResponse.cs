using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Services.Services.Tokens
{
    public class AuthenticatedUserResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
