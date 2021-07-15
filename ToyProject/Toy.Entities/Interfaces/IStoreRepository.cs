using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
   public interface IStoreRepository
    {
        void Delete(Store store);
        void Update(Store store);
        int Insert(Store store);
        Task<Store> Get(int id);
    }
}
