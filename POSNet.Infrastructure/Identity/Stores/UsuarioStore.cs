using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Identity.Stores
{
    public class UsuarioStore : IUserStore<Usuario>, IUserPasswordStore<Usuario>, IUserEmailStore<Usuario>, IUserRoleStore<Usuario>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsersRepository usersRepository;
        private readonly IRolRepository rolRepository;
        private readonly IUserRolRepository userRolRepository;

        public UsuarioStore(IUnitOfWork unitOfWork, IUsersRepository usersRepository, 
            IRolRepository rolRepository, IUserRolRepository userRolRepository)
        {
            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
            this.rolRepository = rolRepository;
            this.userRolRepository = userRolRepository;
        }

        public async Task AddToRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var role = await rolRepository.GetRolByName(roleName);

            if (role == null)
                throw new InvalidOperationException($"El rol '{roleName}' no existe.");

            var exist = await userRolRepository.ExistUserRol(user, role);

            if (!exist)
            {
                await userRolRepository.Create(user, role);
                await unitOfWork.CommitAsymc();
            }

        }

        public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await usersRepository.create(user);
            await unitOfWork.CommitAsymc();

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public async Task<Usuario?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var usuario = await usersRepository.FindByEmailAsync(normalizedEmail);

            return usuario;
        }

        public async Task<Usuario?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (!int.TryParse(userId, out var id)) return await Task.FromResult<Usuario?>(null);
            var user = await usersRepository.FindByIdAsync(id);

            return user;
        }

        public async Task<Usuario?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var usuario = await usersRepository.FindByEmailAsync(normalizedUserName);

            return usuario;
        }

        public Task<string?> GetEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Correo);
        }

        public Task<bool> GetEmailConfirmedAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Nombre + ' ' + user.PrimerApellido);
        }

        public Task<string?> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public async Task<IList<string>> GetRolesAsync(Usuario user, CancellationToken cancellationToken)
        {

            var roles = await userRolRepository.GetRolesAsync(user);

            return roles;
        }

        public Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string?> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Correo);
        }

        public async Task<IList<Usuario>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var users = await userRolRepository.GetUsersInRoleAsync(roleName);
            return users;
        }

        public Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public async Task<bool> IsInRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var exist = await userRolRepository.IsInRoleAsync(user, roleName);

            return exist;
        }

        public async Task RemoveFromRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {

            var role = await rolRepository.GetRolByName(roleName);

            if (role == null)
                throw new InvalidOperationException($"El rol '{roleName}' no existe.");

            var exist = await userRolRepository.ExistUserRol(user, role);

            if (!exist)
            {
                await userRolRepository.Create(user, role);
                await unitOfWork.CommitAsymc();
            }


        }

        public Task SetEmailAsync(Usuario user, string? email, CancellationToken cancellationToken)
        {
            user.Correo = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(Usuario user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetNormalizedEmailAsync(Usuario user, string? normalizedEmail, CancellationToken cancellationToken)
        {
            user.Correo =  normalizedEmail.ToLower();
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(Usuario user, string? normalizedName, CancellationToken cancellationToken)
        {
            user.Nombre = user.Nombre;
            return Task.CompletedTask; 
        }

        public Task SetPasswordHashAsync(Usuario user, string? passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Usuario user, string? userName, CancellationToken cancellationToken)
        {
            user.Nombre = user.Nombre;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await usersRepository.update(user);
            await unitOfWork.CommitAsymc();
            return IdentityResult.Success;

        }
    }
}
