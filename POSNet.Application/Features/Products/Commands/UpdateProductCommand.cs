using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Products.Commands
{
    public record UpdateProductCommand(int Id, int IdCategoria, string Nombre, decimal Precio, int StockInicial, int StockMinimo, string CodigoBarras, string Descripcion) : IRequest<Producto?>
    {
    }
}
