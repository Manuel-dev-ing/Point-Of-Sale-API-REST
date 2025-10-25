using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Products.Queries.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IProductsRepository productsRepository;

        public GetProductQueryHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }


        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var product = await productsRepository.getProduct(request.id);

            return product;

        }
    }
}
