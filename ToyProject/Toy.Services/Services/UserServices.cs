using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepo;
        public UserServices(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task Delete(User user)
        {
            await userRepo.Delete(user);

        }

        public async Task<User> Get(int id)
        {
            var output = await userRepo.Get(id);
            return output;
        }

        public async Task<int> Insert(UserInsertDto userDto)
        {
            var user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Mobile = userDto.Mobile,
                Address = userDto.Address,
                NationalCode=userDto.NationalCode,
                AddedDate=userDto.AddedDate,
                IsActive = userDto.IsActive

            };
            return await userRepo.Insert(user);
        }

        public async Task Update(User user)
        {
            await userRepo.Update(user);
        }
    }
}
