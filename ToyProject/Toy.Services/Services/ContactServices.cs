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
        private readonly IUnitOfWork unitOfWork;
        private readonly IContactRepository contactRepo;

        public ContactServices(IContactRepository contactRepo, IUnitOfWork unitOfWork)
        {
            this.contactRepo = contactRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(Contact contact)
        {
            await contactRepo.Delete(contact);
        }

        public async Task<Contact> Get(int id)
        {
            var output = await contactRepo.Get(id);
            return output;
        }

        public async Task<int> Insert(ContactInsertDto contactDto)
        {
            var contact = new Contact()
            {
                PhoneNumber = contactDto.PhoneNumber,
                Address = contactDto.Address
            };
            return await contactRepo.Insert(contact);
            
        }

        public async Task Update(Contact contact)
        {
            await contactRepo.Update(contact);
        }
    }
}
