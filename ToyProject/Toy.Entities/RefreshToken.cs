using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }


    }
}
