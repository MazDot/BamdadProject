using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
   public interface IUserRepository
    {
        Task Delete(User user);
        Task Update(User user);
        Task<int> Insert(User user);
        Task<User> Get(int id);
    }
}
