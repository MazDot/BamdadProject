    using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities;

namespace Toy.Services.Dto.Input
{
    public class ProductInsertDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string PicURL { get; set; }


    }
}
