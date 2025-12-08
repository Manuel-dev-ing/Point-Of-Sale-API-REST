using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Ventas.Queries.Handlers
{
    public class GetTotalVentasQueryHandler : IRequestHandler<GetTotalVentasQuery, int>
    {
        private readonly IVentasRepository ventasRepository;

        public GetTotalVentasQueryHandler(IVentasRepository ventasRepository)
        {
            this.ventasRepository = ventasRepository;
        }
        public async Task<int> Handle(GetTotalVentasQuery request, CancellationToken cancellationToken)
        {

            var total = await ventasRepository.getTotalVentas();

            return total;
        }
    }
}
