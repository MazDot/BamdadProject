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
        private readonly IPasswordHasher passwordHasher;

        public UserServices(IUserRepository userRepo, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
            this.passwordHasher = passwordHasher;
        }

        public async Task Delete(User user)
        {
            userRepo.Delete(user);
            await unitOfWork.SaveAsync();

        }
        public async Task<User> GetByEmail(string email)
        {
            var output = await userRepo.GetByEmail(email);
            return output;
        }
        public async Task<User> GetByUsername(string username)
        {
            var output = await userRepo.GetByUsername(username);
            return output;
        }

        public async Task<User> Get(int id)
        {
            var output = await userRepo.Get(id);
            return output;
        }

        public async Task<int> Insert(UserInsertDto userDto)
        {
            string passwordHash = passwordHasher.HashPassword(userDto.Password);
            var user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                Role = userDto.Role

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
