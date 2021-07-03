using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Contact> Contacts { get; set; }

    }
}
