using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface IProductRepository
    {
        Task Delete(Product product);
        Task Update(Product product);
        Task<int> Insert(Product product);
        Task<Product> Get(int id);

    }
}
