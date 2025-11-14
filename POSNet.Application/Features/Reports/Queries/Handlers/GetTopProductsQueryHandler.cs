using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Reports.Queries.Handlers
{
    public class GetTopProductsQueryHandler : IRequestHandler<GetTopProductsQuery, List<TopProductsDTO>>
    {
        private readonly IReportsRepository reportsRepository;

        public GetTopProductsQueryHandler(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }


        public async Task<List<TopProductsDTO>> Handle(GetTopProductsQuery request, CancellationToken cancellationToken)
        {
            var topProducts = await reportsRepository.GetTopProducts();
                
            return topProducts;
        }
    }
}
