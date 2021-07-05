using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string NationalCode { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
