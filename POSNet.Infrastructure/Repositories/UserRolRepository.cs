using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class UserRolRepository : IUserRolRepository
    {
        private readonly POSNetDbContext context;

        public UserRolRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsInRoleAsync(Usuario user, string roleName)
        {

            var exist = await context.UsuarioRols
                .AnyAsync(x => x.IdUsuario == user.Id && x.IdRolNavigation.Nombre == roleName);

            return exist;
        }

        public async Task<List<Usuario>> GetUsersInRoleAsync(string roleName)
        {
            var roles = await context.UsuarioRols
                .Where(x => x.IdRolNavigation.Nombre == roleName)
                .Select(x => x.IdUsuarioNavigation)
                .ToListAsync();

            return roles;
        }

        public async Task<List<string>> GetRolesAsync(Usuario user)
        {
            var roles = await context.UsuarioRols
                .Where(x => x.IdUsuario == user.Id)
                .Select(x => x.IdRolNavigation.Nombre)
                .ToListAsync();

            return roles;
        }

        public async Task<bool> ExistUserRol(Usuario user, Rol role)
        {
            var exist = await context.UsuarioRols.AnyAsync(ur => ur.IdUsuario == user.Id && ur.IdRol == role.Id);

            return exist;
        }

        public async Task Create(Usuario user, Rol role)
        {
            context.UsuarioRols.Add(new UsuarioRol()
            {
                IdRol = role.Id,
                IdUsuario = user.Id,
                FechaCreacion = DateTime.Now
            });

        }

        public async Task Delete(Usuario user, Rol role)
        {
            context.UsuarioRols.Remove(new UsuarioRol()
            {
                IdRol = role.Id,
                IdUsuario = user.Id,
                FechaCreacion = DateTime.Now
            });

        }

    }
}
