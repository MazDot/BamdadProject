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
        private readonly IContactRepository contactRepo;
        private readonly IUnitOfWork unitOfWork;

        public ContactServices(IContactRepository contactRepo, IUnitOfWork unitOfWork)
        {
            this.contactRepo = contactRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(Contact contact)
        {
            contactRepo.Delete(contact);
            await unitOfWork.SaveAsync();
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
            var output = contactRepo.Insert(contact);
            await unitOfWork.SaveAsync();
            return (output);

        }

        public async Task Update(Contact contact)
        {
            contactRepo.Update(contact);
            await unitOfWork.SaveAsync();
        }
    }
}
