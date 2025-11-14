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
    public class GetTopUsuariosQueryHandler : IRequestHandler<GetTopUsuarioQuery, List<TopUsuariosDTO>>
    {
        private readonly IReportsRepository reportsRepository;

        public GetTopUsuariosQueryHandler(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }


        public async Task<List<TopUsuariosDTO>> Handle(GetTopUsuarioQuery request, CancellationToken cancellationToken)
        {
            var topUsuarios = await reportsRepository.GetTopUsuarios();

            return topUsuarios;
        }
    }
}
