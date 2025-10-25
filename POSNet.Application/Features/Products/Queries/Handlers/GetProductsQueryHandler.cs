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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsDTO>>
    {
        private readonly IProductsRepository productsRepository;

        public GetProductsQueryHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }


        public async Task<List<ProductsDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var products_dto = await productsRepository.GetProducts();

            return products_dto;
        }
    }
}
