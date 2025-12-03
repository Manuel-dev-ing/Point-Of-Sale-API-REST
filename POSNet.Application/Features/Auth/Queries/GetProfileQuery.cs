using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Common.Models;
using POSNet.Application.DTOs;

namespace POSNet.Application.Features.Auth.Queries
{
    public record GetProfileQuery(string email) : IRequest<profileDTO>
    {
    }
}
