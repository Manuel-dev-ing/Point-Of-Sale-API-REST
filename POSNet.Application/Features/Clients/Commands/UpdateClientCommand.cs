using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSNet.Application.Features.Clients.Commands
{
    public record UpdateClientCommand(int Id, string Nombre, string PrimerApellido, string SegundoApellido, string Correo, string Telefono) : IRequest
    {
    }
}
