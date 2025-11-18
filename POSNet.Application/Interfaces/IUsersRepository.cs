using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IUsersRepository
    {
        Task create(Usuario usuario);
        Task delete(Usuario usuario);
        Task<List<RolDTO>> GetRols();
        Task<UserDTO> GetUserById(int id);
        Task<List<UserDTO>> GetUsers();
        Task update(Usuario usuario);
    }
}
