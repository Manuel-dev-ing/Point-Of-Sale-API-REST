using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IUserRolRepository
    {
        Task Create(Usuario user, Rol role);
        Task Delete(Usuario user, Rol role);
        Task<bool> ExistUserRol(Usuario user, Rol role);
        Task<List<string>> GetRolesAsync(Usuario user);
        Task<List<Usuario>> GetUsersInRoleAsync(string roleName);
        Task<bool> IsInRoleAsync(Usuario user, string roleName);
    }
}
