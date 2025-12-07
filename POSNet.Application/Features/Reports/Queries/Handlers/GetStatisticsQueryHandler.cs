using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Reports.Queries.Handlers
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, ReportStatisticsDTO>
    {
        private readonly IVentasRepository ventasRepository;
        private readonly IProductsRepository productsRepository;

        public GetStatisticsQueryHandler(IVentasRepository ventasRepository, IProductsRepository productsRepository)
        {
            this.ventasRepository = ventasRepository;
            this.productsRepository = productsRepository;
        }
        public async Task<ReportStatisticsDTO> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {

            var ReportStatistics = new ReportStatisticsDTO()
            {
                Ventas = await ventasRepository.getTotalVentas(),
                Ingresos = await ventasRepository.getTotalRevenue(),
                UnidadesTotales = await productsRepository.getTotalUnitsProducts(),
                ValorInventario = await productsRepository.getTotalInventory()
            };

            return ReportStatistics;
        }
    }
}
