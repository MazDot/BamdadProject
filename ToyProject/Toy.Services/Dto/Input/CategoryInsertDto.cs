using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities;

namespace Toy.Services.Dto.Input
{
   public class CategoryInsertDto
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
