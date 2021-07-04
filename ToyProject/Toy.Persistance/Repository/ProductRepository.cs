using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;

namespace Toy.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IUnitOfWork unitOfWOrk;
        private readonly AppDbContext dbContext;

        public ProductRepository(IUnitOfWork unitOfWOrk, AppDbContext dbContext)
        {
            this.unitOfWOrk = unitOfWOrk;
            this.dbContext = dbContext;
        }
        public async Task Delete(Product product)
        {
            dbContext.Remove<Product>(product);
            await unitOfWOrk.SaveAsync();
        }

        public async Task<Product> Get(int id)
        {
            var output = await dbContext.Products.FindAsync(id);
            return output;
        }

        public async Task<int> Insert(Product product)
        {
            dbContext.Add<Product>(product);
            await unitOfWOrk.SaveAsync();
            return product.Id;
        }

        public async Task Update(Product product)
        {
            dbContext.Update<Product>(product);
            await unitOfWOrk.SaveAsync();
        }
    }
}
