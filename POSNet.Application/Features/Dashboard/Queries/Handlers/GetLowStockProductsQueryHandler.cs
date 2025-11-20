using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Dashboard.Queries.Handlers
{
    public class GetLowStockProductsQueryHandler : IRequestHandler<GetLowStockProductsQuery, List<ProductDTO>>
    {
        private readonly IProductsRepository productsRepository;

        public GetLowStockProductsQueryHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetLowStockProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productsRepository.getLowStockProducts();

            return products;
        }
    }
}
