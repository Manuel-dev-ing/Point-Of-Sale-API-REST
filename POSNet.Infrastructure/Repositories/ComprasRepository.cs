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
    public class ComprasRepository : IComprasRepository
    {
        private readonly POSNetDbContext context;

        public ComprasRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<int> getTotalCompras()
        {
            var total = context.Compras.Count();

            return total;
        }

        public async Task createCompra(Compra compra)
        {

            context.Compras.Add(compra);
        }



    }
}
