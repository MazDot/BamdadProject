using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IAppDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;

        public ContactServices(IAppDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(Contact contact)
        {
            dbContext.Contacts.Remove(contact);
            await unitOfWork.SaveAsync();
        }

        public async Task<Contact> Get(int id)
        {
            var output = await dbContext.Contacts.FindAsync(id);
            return output;
        }

        public async Task Insert(ContactInsertDto contactDto)
        {
            var contact = new Contact()
            {
                PhoneNumber = contactDto.PhoneNumber,
                Address = contactDto.Address
            };
            dbContext.Contacts.Add(contact);
            await unitOfWork.SaveAsync();
        }

        public async Task Update(Contact contact)
        {
            dbContext.Contacts.Update(contact);
            await unitOfWork.SaveAsync();
        }
    }
}
