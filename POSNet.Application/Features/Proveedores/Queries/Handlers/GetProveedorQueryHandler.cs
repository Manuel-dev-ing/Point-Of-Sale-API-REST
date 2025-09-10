using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Proveedores.Queries.Handlers
{
    public class GetProveedorQueryHandler : IRequestHandler<GetProveedorQuery, ProveedorDTO?>
    {
        private readonly IProveedoresRepository proveedoresRepository;

        public GetProveedorQueryHandler(IProveedoresRepository proveedoresRepository)
        {
            this.proveedoresRepository = proveedoresRepository;
        }


        public async Task<ProveedorDTO?> Handle(GetProveedorQuery request, CancellationToken cancellationToken)
        {
            var proveedor = await proveedoresRepository.GetProveedor(request.id);
            if (proveedor == null)
            {
                return null;
            }


            return proveedor;
        }
    }
}
