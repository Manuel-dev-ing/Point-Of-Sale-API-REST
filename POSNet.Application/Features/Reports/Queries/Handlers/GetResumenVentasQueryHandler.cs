using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Common.Helpers;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Reports.Queries.Handlers
{
    public class GetResumenVentasQueryHandler : IRequestHandler<GetResumenVentasQuery, List<ResumenVentasDTO>>
    {
        private readonly IReportsRepository reportsRepository;

        public GetResumenVentasQueryHandler(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }

        public async Task<List<ResumenVentasDTO>> Handle(GetResumenVentasQuery request, CancellationToken cancellationToken)
        {
            var resumenVemtas = await reportsRepository.ResumenVentasAsync(request.fechaInicio, request.fechaFin);

            //devulve array con este formato: [06, 07, 08, etc]
            var months = DateFormatHelper.getMonths(resumenVemtas);

            // devulve list de ventas utilizando el array de months([06, 07, 08, etc]) y la data de resumenVemtas
            var resumeVentasDTO = DateFormatHelper.formatSalesResume(months, resumenVemtas);

            return resumeVentasDTO;
        }
    }
}
