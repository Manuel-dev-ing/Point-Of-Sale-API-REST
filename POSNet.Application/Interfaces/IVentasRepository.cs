using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IVentasRepository
    {
        Task createVenta(Venta venta);
        Task<decimal> getTotalRevenue();
        Task<int> getTotalVentas();
    }
}
