using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Common.Models;
using POSNet.Application.DTOs;

namespace POSNet.Application.Features.Auth.Commands
{
    public record LoginCommand(string Email, string Password) : IRequest<RespuestaAutenticacionDTO>
    {
    }

}
