using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly POSNetDbContext context;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IConfiguration config;

        public TokenRepository(POSNetDbContext context, IRefreshTokenRepository refreshTokenRepository, IConfiguration config)
        {
            this.context = context;
            this.refreshTokenRepository = refreshTokenRepository;
            this.config = config;
        }

        public string CreateAccessToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo)
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["llavejwt"]));
            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMinutes(int.Parse(config["AccessTokenExpirationMinutes"]));

            var tokenSeguridad = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: credenciales);

            var jwt = new JwtSecurityToken(
                issuer: null,     // Debe coincidir con la validación
                audience: null,   // Debe coincidir con la validación
                claims: claims,
                expires: expiracion,
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public async Task<RespuestaAutenticacionDTO> CreateTokensAsync(Usuario user, IEnumerable<Claim>? extraClaims = null)
        {
            var accessToken = CreateAccessToken(user);
            var refreshToken = CreateRefreshToken();

            var hash = ComputeSha256Hash(refreshToken);
            var refreshExpDays = int.Parse(config["AccessTokenExpirationMinutes"]);
            var expires = DateTime.UtcNow.AddDays(refreshExpDays);

            await refreshTokenRepository.SaveRefreshTokenAsync(user.Id.ToString(), hash, expires, null);
            var accessExpires = DateTime.UtcNow.AddMinutes(int.Parse("5"));

            return new RespuestaAutenticacionDTO
            {
                token = accessToken,
                expiracion = accessExpires,
                refreshToken = refreshToken

            };
        }


        public string CreateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private static string ComputeSha256Hash(string raw)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
            return Convert.ToHexString(bytes); // .NET 5+
        }


    }
}