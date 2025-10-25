using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Ventas.Commands
{
    public record CreateVentaCommand(int IdCliente, int IdUsuario, int NumeroVenta, decimal SubTotal, decimal Total, IEnumerable<DetalleVentaDTO> DetalleVenta) : IRequest
    {
    }
}
