using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public List<Comment> Comments { get; set; }
        public int AgeRestriction { get; set; }
        public bool IsMale { get; set; }
        public string InfluenceCategory { get; set; }


    }
}
