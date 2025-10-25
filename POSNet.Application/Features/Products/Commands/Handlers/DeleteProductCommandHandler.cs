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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Producto?>
    {
        private readonly IProductsRepository productsRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IProductsRepository productsRepository, IUnitOfWork unitOfWork)
        {
            this.productsRepository = productsRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Producto?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var producto = await productsRepository.getProductoById(request.id);

            if (producto == null)
            {
                return null;
            }

            producto.Estado = false;
            await productsRepository.update(producto);

            await unitOfWork.CommitAsymc();

            return producto;
        }
    }
}
