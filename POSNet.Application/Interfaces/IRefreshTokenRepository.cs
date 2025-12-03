using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByHashAsync(string tokenHash);
        Task RevokeAsync(RefreshToken token, string? replacedByHash = null);
        Task SaveRefreshTokenAsync(string userId, string refreshTokenHash, DateTime expires, string? deviceInfo);
    }
}
