using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public interface IProductServices
    {
        Task<int> Insert(ProductInsertDto contactDto, int userId);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAllByUserId(int userId);
        Task Update(Product contact);
        Task Delete(Product contact);
        Task<IEnumerable<Product>> GetByCategory(string category);

    }
}
