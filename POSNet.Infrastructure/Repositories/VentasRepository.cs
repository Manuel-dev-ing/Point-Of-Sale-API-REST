using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class VentasRepository : IVentasRepository
    {
        private readonly POSNetDbContext context;

        public VentasRepository(POSNetDbContext context)
        {
            this.context = context;
        }


        public async Task createVenta(Venta venta)
        {

            context.Ventas.Add(venta);

        }

       

    }
}
