using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface ITokenRepository
    {
        string CreateAccessToken(Usuario usuario);
        string CreateRefreshToken();
        Task<RespuestaAutenticacionDTO> CreateTokensAsync(Usuario user, IEnumerable<Claim>? extraClaims = null);
    }
}
