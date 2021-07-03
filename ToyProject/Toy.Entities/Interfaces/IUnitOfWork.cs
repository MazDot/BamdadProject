using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

    }
}
