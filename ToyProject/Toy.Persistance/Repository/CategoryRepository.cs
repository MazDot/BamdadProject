using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;

namespace Toy.Persistance.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;
        public CategoryRepository(IUnitOfWork unitOfWOrk, AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Category category)
        {
            dbContext.Remove<Category>(category);
        }

        public async Task<Category> Get(int id)
        {
            var output = await dbContext.Categories.FindAsync(id);
            return output;
        }

        public int Insert(Category category)
        {
            dbContext.Add<Category>(category);
            return category.Id;
        }

        public void Update(Category category)
        {
            dbContext.Update<Category>(category);
        }
    }
}
