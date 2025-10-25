using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Products.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductsRepository productsRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork)
        {
            this.productsRepository = productsRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

          
            var producto = new Producto()
            {
                IdCategoria = request.IdCategoria,
                Nombre = request.Nombre,
                Precio = request.Precio,
                StockInicial = request.StockInicial,
                StockMinimo = request.StockMinimo,
                CodigoBarras = request.CodigoBarras,
                Descripcion = request.Descripcion,
                Estado = true
            };

            await productsRepository.guardar(producto);
            await unitOfWork.CommitAsymc();

            var productoDTO = new ProductDTO()
            {
                Id = producto.Id,
                IdCategoria = (int)producto.IdCategoria,
                Nombre = producto.Nombre,
                Precio = (decimal)producto.Precio,
                StockInicial = (int)producto.StockInicial,
                StockMinimo = (int)producto.StockMinimo,
                CodigoBarras = producto.CodigoBarras,
                Descripcion = producto.Descripcion,
                Estado = (bool)producto.Estado
            };

            return productoDTO;
        }
    }
}
