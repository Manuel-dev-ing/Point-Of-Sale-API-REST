using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;

namespace POSNet.Application.Features.Categories.Queries
{
    public record GetCategoryQuery(int id) : IRequest<CategoryDTO>
    {
    }
}
