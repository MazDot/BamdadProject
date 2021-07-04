using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities;

namespace Toy.Services.Dto.Input
{
    public class ProductInsertDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public int AgeRestriction { get; set; }
        public bool IsMale { get; set; }
        public string InfluenceCategory { get; set; }

    }
}
