using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;

namespace Toy.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Product product)
        {
            dbContext.Remove<Product>(product);
        }

        public async Task<Product> Get(int id)
        {
            var output = await dbContext.Products.FindAsync(id);
            return output;
        }

        public async Task<IEnumerable<Product>> GetAllByUserId(int userId)
        {
            IEnumerable<Product> output = dbContext.Products.Where(x => x.UserId == userId);
            return output;
        }
        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            var output = dbContext.Products.Where(x => x.Category == category);
            return output;

        }

        public int Insert(Product product)
        {
            dbContext.Add<Product>(product);
            return product.Id;
        }

        public void Update(Product product)
        {
            dbContext.Update<Product>(product);
        }
    }
}
