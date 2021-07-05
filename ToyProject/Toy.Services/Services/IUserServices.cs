using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
   public interface IUserServices
    {
        Task<int> Insert(UserInsertDto userDto);
        Task<User> Get(int id);
        Task Update(User user);
        Task Delete(User user);
    }
}
