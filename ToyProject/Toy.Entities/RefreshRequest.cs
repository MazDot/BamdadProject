using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Toy.Entities
{
    public class RefreshRequest
    {
        [Required]
        public string RefreshToken { get; set; }


    }
}
