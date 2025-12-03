using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly POSNetDbContext context;

        public UsersRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<profileDTO> GetProfile(string email)
        {
            var user = await context.Usuarios
                .Where(x => x.Estado == true && x.Correo == email)
                .Select(x => new profileDTO
                {
                    Id = x.Id,
                    IdRol = (int)x.IdRol,
                    NombreRol = x.IdRolNavigation.Nombre,
                    Nombre = x.Nombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido
                
                }).FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<RolDTO>> GetRols()
        {
            var rols = await context.Rols
                .Select(x => new RolDTO()
                {
                    Id = x.Id,
                    Nombre = x.Nombre

                }).ToListAsync();

            return rols;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await context.Usuarios
                   .Where(x => x.Estado == true)
                   .Select(x => new UserDTO()
                   {
                       Id = x.Id,
                       IdRol = x.IdRol,
                       Nombre = x.Nombre,
                       PrimerApellido = x.PrimerApellido,
                       SegundoApellido = x.SegundoApellido,
                       Correo = x.Correo,
                       Password = x.Password,
                       Estado = x.Estado,
                       FechaCreacion = x.FechaCreacion
                   }).ToListAsync();

            return users;
        }

        public async Task<Usuario> FindByEmailAsync(string email)
        {
            var user = await context.Usuarios
                .Where(x => x.Correo == email && x.Estado == true)
                .FirstOrDefaultAsync();


            return user;
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            var user = await context.Usuarios
                .Where(x => x.Id == id && x.Estado == true)
                .FirstOrDefaultAsync();
                

            return user;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await context.Usuarios
                .Where(x => x.Id == id && x.Estado == true)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    IdRol = x.IdRol,
                    Nombre = x.Nombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    Correo = x.Correo,
                    Estado = x.Estado
                }).FirstOrDefaultAsync();

            return user;
        }

        public async Task create(Usuario usuario)
        {

            await context.Usuarios.AddAsync(usuario);

        }

        public async Task update(Usuario usuario)
        {

           context.Usuarios.Update(usuario);

        }

        public async Task delete(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
        }


    }
}
