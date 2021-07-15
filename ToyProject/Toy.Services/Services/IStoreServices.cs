using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
   public interface IStoreServices
    {
        Task<int> Insert(StoreInsertDto store);
        Task<Store> Get(int id);
        Task Update(Store store);
        Task Delete(Store store);
    }
}
