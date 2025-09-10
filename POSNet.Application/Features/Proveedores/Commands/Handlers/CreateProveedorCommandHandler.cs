using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Proveedores.Commands.Handlers
{
    public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, ProveedorDTO>
    {
        private readonly IProveedoresRepository proveedoresRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateProveedorCommandHandler(IProveedoresRepository proveedoresRepository, IUnitOfWork unitOfWork)
        {
            this.proveedoresRepository = proveedoresRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<ProveedorDTO> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
        {

            var proveedor = new Proveedore()
            {
                IdCiudad = request.IdCiudad,
                Nombre = request.Nombre,
                PrimerApellido = request.PrimerApellido,
                SegundoApellido = request.SegundoApellido,
                Correo = request.Correo,
                Telefono = request.Telefono,
                Colonia = request.Colonia,
                CodigoPostal = request.CodigoPostal,
                Estado = true

            };
            await proveedoresRepository.AddAsync(proveedor);
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
