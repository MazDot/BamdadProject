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
        public ContactRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(Contact contact)
        {
            dbContext.Remove<Contact>(contact);
        }

        public async Task<Contact> Get(int id)
        {
            var output = await dbContext.Contacts.FindAsync(id);
            return output;
        }

        public int Insert(Contact contact)
        {
            dbContext.Add<Contact>(contact);
            return contact.Id;
        }

        public void Update(Contact contact)
        {
            dbContext.Update<Contact>(contact);
        }

    }
}
