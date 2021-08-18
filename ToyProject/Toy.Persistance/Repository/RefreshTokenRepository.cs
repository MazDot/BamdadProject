using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Toy.Persistance.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext dbContext;
        public RefreshTokenRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(RefreshToken refreshToken)
        {
            dbContext.Add<RefreshToken>(refreshToken);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAll(int id)
        {
            var allTokens = await dbContext.RefreshTokens.Where(x => x.UserId == id).ToListAsync();
            dbContext.RemoveRange(allTokens);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteToken(RefreshToken token)
        {
            dbContext.Remove<RefreshToken>(token);
            await dbContext.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            RefreshToken refreshToken = dbContext.RefreshTokens.FirstOrDefault(x => x.Token == token);
            return refreshToken;

        }
    }
}
