using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Services.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);

    }
}
