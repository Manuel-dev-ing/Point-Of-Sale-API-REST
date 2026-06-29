using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Compras.Commands.Handlers
{
    public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IComprasRepository comprasRepository;
        private readonly IProductsRepository productsRepository;
        private readonly IMovementRepository movementRepository;

        public CreateCompraCommandHandler(IUnitOfWork unitOfWork, IComprasRepository comprasRepository, IProductsRepository productsRepository, IMovementRepository movementRepository)
        {
            this.unitOfWork = unitOfWork;
            this.comprasRepository = comprasRepository;
            this.productsRepository = productsRepository;
            this.movementRepository = movementRepository;
        }

        public async Task Handle(CreateCompraCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();

                var compra = new Compra()
                {
                    IdUsuario = request.IdUsuario,
                    IdProveedor = request.IdProveedor,
                    NumeroCompra = request.NumeroCompra.ToString(),
                    SubTotal = request.SubTotal,
                    Total = request.Total,
                    Fecha = DateOnly.FromDateTime(DateTime.Now),
                    DetalleCompras = request.DetalleCompra.Select(x => new DetalleCompra()
                    {
                        IdProducto = x.IdProducto,
                        Cantidad = x.Cantidad,
                        Precio = x.Precio,
                        Total = x.Total

                    }).ToList()
                };

                foreach (var item in request.DetalleCompra)
                {
                    var producto = await productsRepository.getProductoById(item.IdProducto);
                    producto.StockInicial += item.Cantidad;

                    var movement = new Movimiento()
                    {
                        IdUsuario = request.IdUsuario,
                        IdProducto = item.IdProducto,
                        Motivo = "Compra",
                        Cantidad = item.Cantidad,
                        Tipo = "entrada",
                        Fecha = DateOnly.FromDateTime(DateTime.Now)
                    };

                    //agregar movimiento
                    await movementRepository.crear(movement);


                    await productsRepository.update(producto);
                }

                await comprasRepository.createCompra(compra);
                await unitOfWork.CommitAsymc();

            }
            catch (Exception)
            {

                await unitOfWork.RollbackAsync();
            }

            
        }
    }
}
