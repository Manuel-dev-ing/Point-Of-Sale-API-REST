using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Products.Commands
{
    public record DeleteProductCommand(int id) : IRequest<Producto?>
    {
    }
}
