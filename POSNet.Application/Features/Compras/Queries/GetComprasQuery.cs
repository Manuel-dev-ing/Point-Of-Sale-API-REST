using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSNet.Application.Features.Compras.Queries
{
    public record GetComprasQuery() : IRequest<int>
    {
    }
}
