using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface IContactRepository
    {
        void Delete(Contact contact);
        void Update(Contact contact);
        int Insert(Contact contact);
        Task<Contact> Get(int id);

    }
}
