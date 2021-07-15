using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Services.Dto.Input
{
    public class StoreInsertDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
