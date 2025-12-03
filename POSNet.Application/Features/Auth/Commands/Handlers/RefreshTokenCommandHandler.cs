using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSNet.Application.Common.Exceptions;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Auth.Commands.Handlers
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RespuestaAutenticacionDTO>
    {
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly UserManager<Usuario> userManager;
        private readonly ITokenRepository tokenRepository;

        public RefreshTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository, UserManager<Usuario> userManager, ITokenRepository tokenRepository)
        {
            this.refreshTokenRepository = refreshTokenRepository;
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        public async Task<RespuestaAutenticacionDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                throw new DomainException("No refresh token");
            }
            var incomingHash = ComputeSha256Hash(request.RefreshToken);
            var stored = await refreshTokenRepository.GetByHashAsync(incomingHash);
            if (stored == null)
            {
                throw new DomainException("Invalid refresh token");
            }
            if (stored.Revoked.HasValue)
            {
                throw new DomainException("Token revoked");
            }
            if (stored.Expires < DateTime.UtcNow)
            {
                throw new DomainException("Token expired");

            }

            var user = await userManager.FindByIdAsync(stored.IdUsuario.ToString());

            var newRefresh = tokenRepository.CreateRefreshToken();
            var newHash = ComputeSha256Hash(newRefresh);
            await refreshTokenRepository.RevokeAsync(stored, newHash);
            await refreshTokenRepository.SaveRefreshTokenAsync(user.Id.ToString(), newHash, DateTime.UtcNow.AddDays(int.Parse("7")), null);

            var accesToken = tokenRepository.CreateAccessToken(user);
            var accesExpires = DateTime.UtcNow.AddMinutes(int.Parse("15"));

            return new RespuestaAutenticacionDTO
            {
                token = accesToken,
                refreshToken = newRefresh,
                expiracion = accesExpires
            };
        }



        private static string ComputeSha256Hash(string raw)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(raw));
            return Convert.ToHexString(bytes);
        }
    }
}
