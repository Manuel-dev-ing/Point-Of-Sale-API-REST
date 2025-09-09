using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSNet.Application.Features.Clients.Commands
{
    public record DeleteClientCommand(int id) : IRequest
    {
    }
}
