using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string PicURL { get; set; }
        public List<Comment> Comments { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }


    }
}
