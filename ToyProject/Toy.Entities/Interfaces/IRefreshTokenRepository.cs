using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Entities.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task Create(RefreshToken refreshToken);
        Task<RefreshToken> GetByToken(string token);
        Task DeleteToken(RefreshToken Token);
        Task DeleteAll(int id);

    }
}
