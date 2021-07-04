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
        Task<int> Insert(ProductInsertDto contactDto);
        Task<Product> Get(int id);
        Task Update(Product contact);
        Task Delete(Product contact);

    }
}
