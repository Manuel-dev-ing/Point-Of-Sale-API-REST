using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Products.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Producto?>
    {
        private readonly IProductsRepository productsRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork)
        {
            this.productsRepository = productsRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Producto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var producto = await productsRepository.getProductoById(request.Id);
            if (producto == null)
            {
                return null;
            }

            producto.IdCategoria = request.IdCategoria;
            producto.Nombre = request.Nombre;
            producto.Precio = request.Precio;
            producto.StockInicial = request.StockInicial;
            producto.StockMinimo = request.StockMinimo;
            producto.CodigoBarras = request.CodigoBarras;
            producto.Descripcion = request.Descripcion;

            await productsRepository.update(producto);
            await unitOfWork.CommitAsymc();

            return producto;
        }
    }
}
