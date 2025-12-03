using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly POSNetDbContext context;

        public RefreshTokenRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task SaveRefreshTokenAsync(string userId, string refreshTokenHash, DateTime expires, string? deviceInfo)
        {
            var entity = new RefreshToken { IdUsuario = Convert.ToInt32(userId), TokenHash = refreshTokenHash, Expires = expires, Created = DateTime.UtcNow, DeviceInfo = deviceInfo };
            context.RefreshTokens.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByHashAsync(string tokenHash)
        {
            return await context.RefreshTokens.FirstOrDefaultAsync(r => r.TokenHash == tokenHash);
        }

        public async Task RevokeAsync(RefreshToken token, string? replacedByHash = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.ReplacedByTokenHash = replacedByHash;
            context.RefreshTokens.Update(token);
        }

    }
}
