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
    public class UpdateProveedorCommandHandler : IRequestHandler<UpdateProveedorCommand, ProveedorDTO?>
    {
        private readonly IProveedoresRepository proveedoresRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateProveedorCommandHandler(IProveedoresRepository proveedoresRepository, IUnitOfWork unitOfWork)
        {
            this.proveedoresRepository = proveedoresRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProveedorDTO?> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
        {

            var proveedor = await proveedoresRepository.GetProveedorId(request.Id);

            if (proveedor == null)
                return null;
            proveedor.Id = request.Id;
            proveedor.IdCiudad = request.IdCiudad;
            proveedor.Nombre = request.Nombre;
            proveedor.PrimerApellido = request.PrimerApellido;
            proveedor.SegundoApellido = request.SegundoApellido;
            proveedor.Correo = request.Correo;
            proveedor.Telefono = request.Telefono;
            proveedor.Colonia = request.Colonia;
            proveedor.CodigoPostal = request.CodigoPostal;
           
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
