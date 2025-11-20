using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Dashboard.Queries.Handlers
{
    public class GetResumeDashboardQueryHandler : IRequestHandler<GetResumeDashboardQuery, ResumenDashboardDTO>
    {
        private readonly IVentasRepository ventasRepository;
        private readonly IProductsRepository productsRepository;
        private readonly IClientsRepository clientsRepository;

        public GetResumeDashboardQueryHandler(IVentasRepository ventasRepository, IProductsRepository productsRepository, IClientsRepository clientsRepository)
        {
            this.ventasRepository = ventasRepository;
            this.productsRepository = productsRepository;
            this.clientsRepository = clientsRepository;
        }
        public async Task<ResumenDashboardDTO> Handle(GetResumeDashboardQuery request, CancellationToken cancellationToken)
        {
            var resumeDashboard = new ResumenDashboardDTO()
            {
                ventas = await ventasRepository.getTotalVentas(),
                ingresos = await ventasRepository.getTotalRevenue(),
                productos = await productsRepository.getTotalProducts(),
                clientes = await clientsRepository.getTotalClients()
            };

            return resumeDashboard;

        }
    }
}
