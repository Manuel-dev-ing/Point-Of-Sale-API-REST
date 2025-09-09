using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;

namespace POSNet.Application.Features.Clients.Commands
{
    public record CreateClientCommand(string Nombre, string PrimerApellido, string SegundoApellido, string Correo, string Telefono) : IRequest<ClientDTO>
    {
    }
}
