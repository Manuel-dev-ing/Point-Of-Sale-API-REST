using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSNet.Application.Features.Categories.Commands
{
    public record DeleteCategoryCommand(int id) : IRequest
    {
    }
}
