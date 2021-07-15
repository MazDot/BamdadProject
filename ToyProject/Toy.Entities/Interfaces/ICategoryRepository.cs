using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface ICategoryRepository
    {
        void Delete(Category category);
        void Update(Category category);
        int Insert(Category category);
        Task<Category> Get(int id);
    }
}
