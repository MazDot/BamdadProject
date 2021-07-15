using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
   public interface ICategoryServices
    {
        Task<int> Insert(CategoryInsertDto categoryDto);
        Task<Category> Get(int id);
        Task Update(Category contact);
        Task Delete(Category contact);
    }
}
