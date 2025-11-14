using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;

namespace POSNet.Application.Interfaces
{
    public interface IReportsRepository
    {
        Task<List<TopProductsDTO>> GetTopProducts();
        Task<List<TopUsuariosDTO>> GetTopUsuarios();
        Task<List<VentasCategoriaDTO>> GetVentasCategorias();
        Task<List<ResumenVentasDTO>> ResumenVentasAsync(string fechaInicio, string fechaFin);
    }
}
