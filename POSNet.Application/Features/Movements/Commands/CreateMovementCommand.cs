using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSNet.Application.Features.Movements.Commands
{
    public record CreateMovementCommand(int idUsuario, int idProducto, string movimiento, int cantidad, string motivo) : IRequest
    {
    }


}
