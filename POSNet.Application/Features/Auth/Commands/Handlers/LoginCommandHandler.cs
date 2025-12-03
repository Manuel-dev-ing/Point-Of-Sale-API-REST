using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSNet.Application.Common.Exceptions;
using POSNet.Application.Common.Models;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Auth.Commands.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, RespuestaAutenticacionDTO>
    {
        private readonly SignInManager<Usuario> signInManager;
        private readonly UserManager<Usuario> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;

        public LoginCommandHandler(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, ITokenRepository tokenRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.refreshTokenRepository = refreshTokenRepository;
        }


        public async Task<RespuestaAutenticacionDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new DomainException("Credenciales inválidas");
            }

            var password = await userManager.CheckPasswordAsync(user, request.Password);
            if (!password) throw new DomainException("Credenciales inválidas");

            var resultado = await tokenRepository.CreateTokensAsync(user);

            return resultado;
        }
    }
}
