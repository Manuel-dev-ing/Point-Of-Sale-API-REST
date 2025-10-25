using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;

namespace POSNet.Application.Features.Compras.Commands
{
    public record CreateCompraCommand(int IdUsuario, int IdProveedor, int NumeroCompra, decimal SubTotal, decimal Total, IEnumerable<DetalleCompraDTO> DetalleCompra) : IRequest
    {
    }
}
