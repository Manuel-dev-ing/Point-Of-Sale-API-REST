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
    public class GetVentasCategoriasQueryHandler : IRequestHandler<GetVentasCategoriasQuery, List<VentasCategoriaDTO>>
    {
        private readonly IReportsRepository reportsRepository;

        public GetVentasCategoriasQueryHandler(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }

        public async Task<List<VentasCategoriaDTO>> Handle(GetVentasCategoriasQuery request, CancellationToken cancellationToken)
        {

            var ventasCategoria = await reportsRepository.GetVentasCategorias();

            return ventasCategoria;
        }
    }
}
