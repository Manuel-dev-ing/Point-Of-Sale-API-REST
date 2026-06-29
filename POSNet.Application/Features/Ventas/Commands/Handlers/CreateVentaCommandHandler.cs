using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Ventas.Commands.Handlers
{
    public class CreateVentaCommandHandler : IRequestHandler<CreateVentaCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVentasRepository ventasRepository;
        private readonly IProductsRepository productsRepository;
        private readonly IMovementRepository movementRepository;

        public CreateVentaCommandHandler(IUnitOfWork unitOfWork, IVentasRepository ventasRepository, IProductsRepository productsRepository, IMovementRepository movementRepository)
        {
            this.unitOfWork = unitOfWork;
            this.ventasRepository = ventasRepository;
            this.productsRepository = productsRepository;
            this.movementRepository = movementRepository;
        }

        public async Task Handle(CreateVentaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();

                var venta = new Venta()
                {
                    IdUsuario = request.IdUsuario,
                    IdCliente = request.IdCliente,
                    NumeroVenta = request.NumeroVenta.ToString(),
                    SubTotal = Convert.ToDecimal(request.SubTotal),
                    Total = Convert.ToDecimal(request.Total),
                    Fecha = DateOnly.FromDateTime(DateTime.Now),
                    DetalleVenta = request.DetalleVenta.Select(x => new DetalleVentum()
                    {
                        IdProducto = x.IdProducto,
                        Cantidad = x.Cantidad,
                        Precio = x.Precio,
                        Total = x.Total

                    }).ToList()

                };

                

                foreach (var item in request.DetalleVenta)
                {
                    var producto = await productsRepository.getProductoById(item.IdProducto);
                    producto.StockInicial -= item.Cantidad;

                    //
                    var movement = new Movimiento()
                    {
                        IdUsuario = request.IdUsuario,
                        IdProducto = item.IdProducto,
                        Motivo = "Venta",
                        Cantidad = item.Cantidad,
                        Tipo = "salida",
                        Fecha = DateOnly.FromDateTime(DateTime.Now)
                    };

                    //agregar movimiento
                    await movementRepository.crear(movement);

                    await productsRepository.update(producto);

                
                }

                await ventasRepository.createVenta(venta);
                await unitOfWork.CommitAsymc();


            }
            catch
            {
                await unitOfWork.RollbackAsync();
                
            }

            

            
        }
    }
}
