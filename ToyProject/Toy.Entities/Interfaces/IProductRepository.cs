using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface IProductRepository
    {
        void Delete(Product product);
        void Update(Product product);
        int Insert(Product product);
        Task<Product> Get(int id);

    }
}
