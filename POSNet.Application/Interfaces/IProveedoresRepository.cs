using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IProveedoresRepository
    {
        Task AddAsync(Proveedore proveedore);
        Task<ProveedorDTO> GetProveedor(int id);
        Task<List<ProveedoresDTO>> GetProveedoresAsync();
        Task<Proveedore> GetProveedorId(int id);
        Task UpdateAsync(Proveedore proveedore);
    }
}
