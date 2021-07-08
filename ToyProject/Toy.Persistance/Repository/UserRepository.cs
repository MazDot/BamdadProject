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
        private readonly AppDbContext dbContext;
        public UserRepository(IUnitOfWork unitOfWOrk, AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       

        public void Delete(User user)
        {
            dbContext.Remove<User>(user);
        }

        public async Task<User> Get(int id)
        {
            var output = await dbContext.Users.FindAsync(id);
            return output;
        }

        public int Insert(User user)
        {
            dbContext.Add<User>(user);
            return user.Id;
        }

        public void Update(User user)
        {
            dbContext.Update<User>(user);
        }
    }
}
