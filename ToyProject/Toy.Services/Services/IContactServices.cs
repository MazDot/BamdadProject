using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Services.Dto.Input;

namespace Toy.Services.Services
{
    public interface IContactServices
    {
        Task Insert(ContactInsertDto contactDto);
        Task<Contact> Get(int id);
        Task Update(Contact contact);
        Task Delete(Contact contact);

    }
}
