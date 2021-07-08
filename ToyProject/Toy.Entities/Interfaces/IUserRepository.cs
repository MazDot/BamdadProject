using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
   public interface IUserRepository
    {
        void Delete(User user);
        void Update(User user);
        int Insert(User user);
        Task<User> Get(int id);
    }
}
