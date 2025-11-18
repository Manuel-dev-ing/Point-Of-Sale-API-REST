using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSNet.Application.Features.Users.Command
{
    public record UpdateUserCommand(int id, int idRol, string Nombre, string PrimerApellido, string SegundoApellido, string Correo, bool Estado) : IRequest
    {
    }
}
