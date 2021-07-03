using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities.Interfaces;

namespace Toy.Persistance.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
