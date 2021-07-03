using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface IContactRepository
    {
        Task Delete(Contact contact);
        Task Update(Contact contact);
        Task<int> Insert(Contact contact);
        Task<Contact> Get(int id);

    }
}
