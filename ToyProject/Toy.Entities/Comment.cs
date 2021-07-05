using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class Comment : BaseEntity
    {
        public string Description { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }


    }
}
