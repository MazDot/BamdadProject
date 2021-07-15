using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;

namespace Toy.Persistance.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext dbContext;
        public StoreRepository(IUnitOfWork unitOfWOrk, AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Store store)
        {
            dbContext.Remove<Store>(store);

        }

        public async Task<Store> Get(int id)
        {
            var output = await dbContext.Stores.FindAsync(id);
            return output;
        }

        public int Insert(Store store)
        {
            dbContext.Add<Store>(store);
            return store.Id;
        }

        public void Update(Store store)
        {
            dbContext.Update<Store>(store);
        }
    }
}
