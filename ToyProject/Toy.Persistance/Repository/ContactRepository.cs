using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;

namespace Toy.Persistance.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        public ContactRepository(AppDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(Contact contact)
        {
            dbContext.Remove<Contact>(contact);
            await unitOfWork.SaveAsync();
        }

        public async Task<Contact> Get(int id)
        {
            var output = await dbContext.Contacts.FindAsync(id);
            return output;
        }

        public async Task<int> Insert(Contact contact)
        {
            dbContext.Add<Contact>(contact);
            await unitOfWork.SaveAsync();
            return contact.Id;
        }

        public async Task Update(Contact contact)
        {
            dbContext.Update<Contact>(contact);
            await unitOfWork.SaveAsync();
        }

    }
}
