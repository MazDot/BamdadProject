using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Entities;
using Toy.Entities.Interfaces;

namespace Toy.Persistance.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

    }
}
