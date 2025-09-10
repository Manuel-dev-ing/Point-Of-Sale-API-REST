using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Proveedores.Queries.Handlers
{
    public class ListProveedoresQueryHandler : IRequestHandler<GetProveedoresQuery, List<ProveedoresDTO>>
    {
        private readonly IProveedoresRepository proveedoresRepository;

        public ListProveedoresQueryHandler(IProveedoresRepository proveedoresRepository)
        {
            this.proveedoresRepository = proveedoresRepository;
        }


        public async Task<List<ProveedoresDTO>> Handle(GetProveedoresQuery request, CancellationToken cancellationToken)
        {
            var proveedoresDTO = await proveedoresRepository.GetProveedoresAsync();


            return proveedoresDTO;
        }
    }
}
