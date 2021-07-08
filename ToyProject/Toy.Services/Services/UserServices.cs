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
        private readonly IUnitOfWork unitOfWork;

        public UserServices(IUserRepository userRepo, IUnitOfWork unitOfWork)
        {
            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(User user)
        {
            userRepo.Delete(user);
            await unitOfWork.SaveAsync();

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
            var output = userRepo.Insert(user);
            await unitOfWork.SaveAsync();
            return (output);
        }

        public async Task Update(User user)
        {
            userRepo.Update(user);
            await unitOfWork.SaveAsync();
        }
    }
}
