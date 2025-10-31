using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Movements.Commands.Handlers
{
    public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMovementRepository movementRepository;
        private readonly IProductsRepository productsRepository;

        public CreateMovementCommandHandler(IUnitOfWork unitOfWork, IMovementRepository movementRepository, IProductsRepository productsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.movementRepository = movementRepository;
            this.productsRepository = productsRepository;
        }

        public async Task Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();

                var producto = await productsRepository.getProductoById(request.idProducto);

                if (request.movimiento == "entrada")
                {
                    producto.StockInicial += request.cantidad;
                }
                else if(request.movimiento == "salida")
                {
                    producto.StockInicial -= request.cantidad;

                }


                await productsRepository.update(producto);


                var movement = new Movimiento()
                {
                    IdUsuario = request.idUsuario,
                    IdProducto = request.idProducto,
                    Motivo = request.motivo,
                    Cantidad = request.cantidad,
                    Tipo = request.movimiento,
                    Fecha = DateOnly.FromDateTime(DateTime.Now)
                };

                await movementRepository.crear(movement);

                await unitOfWork.CommitAsymc();

            }
            catch
            {

                await unitOfWork.RollbackAsync();

            }

            

        }
    }
}
