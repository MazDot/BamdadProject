using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;

namespace Toy.Persistance.Repository
{
   public class UserRepository: IUserRepository
    {
        private readonly IUnitOfWork unitOfWOrk;
        private readonly AppDbContext dbContext;
        public UserRepository(IUnitOfWork unitOfWOrk, AppDbContext dbContext)
        {
            this.unitOfWOrk = unitOfWOrk;
            this.dbContext = dbContext;
        }
       

        public async Task Delete(User user)
        {
            dbContext.Remove<User>(user);
            await unitOfWOrk.SaveAsync();
        }

        public async Task<User> Get(int id)
        {
            var output = await dbContext.Users.FindAsync(id);
            return output;
        }

        public async Task<int> Insert(User user)
        {
            dbContext.Add<User>(user);
            await unitOfWOrk.SaveAsync();
            return user.Id;
        }

        public async Task Update(User user)
        {
            dbContext.Update<User>(user);
            await unitOfWOrk.SaveAsync();
        }
    }
}
