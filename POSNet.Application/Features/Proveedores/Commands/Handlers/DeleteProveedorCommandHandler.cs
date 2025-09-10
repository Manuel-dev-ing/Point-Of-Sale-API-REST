using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Proveedores.Commands;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Proveedores.Commands.Handlers
{
    public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, ProveedorDTO?>
    {
        private readonly IProveedoresRepository proveedoresRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteProveedorCommandHandler(IProveedoresRepository proveedoresRepository, IUnitOfWork unitOfWork)
        {
            this.proveedoresRepository = proveedoresRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProveedorDTO> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedor = await proveedoresRepository.GetProveedorId(request.id);
            if (proveedor == null)
            {
                return null;
            }
            proveedor.Estado = false;

            await proveedoresRepository.UpdateAsync(proveedor);
            await unitOfWork.CommitAsymc();

            var proveedor_dto = new ProveedorDTO()
            {
                Id = proveedor.Id,
                IdCiudad = (int)proveedor.IdCiudad,
                Nombre = proveedor.Nombre,
                PrimerApellido = proveedor.PrimerApellido,
                SegundoApellido = proveedor.SegundoApellido,
                Correo = proveedor.Correo,
                Telefono = proveedor.Telefono,
                Colonia = proveedor.Colonia,
                CodigoPostal = proveedor.CodigoPostal,
                Estado = (bool)proveedor.Estado
            };

            return proveedor_dto;
        }
    }
}
