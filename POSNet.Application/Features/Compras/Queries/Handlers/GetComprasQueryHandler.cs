using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Compras.Queries.Handlers
{
    public class GetComprasQueryHandler : IRequestHandler<GetComprasQuery, int>
    {
        private readonly IComprasRepository comprasRepository;

        public GetComprasQueryHandler(IComprasRepository comprasRepository)
        {
            this.comprasRepository = comprasRepository;
        }


        public async Task<int> Handle(GetComprasQuery request, CancellationToken cancellationToken)
        {

            var total = await comprasRepository.getTotalCompras();

            return total;
        }
    }
}
