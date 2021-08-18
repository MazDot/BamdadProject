using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Toy.Services.Dto.Input
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
