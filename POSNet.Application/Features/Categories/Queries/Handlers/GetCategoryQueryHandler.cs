using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Categories.Queries.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDTO>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public async Task<CategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryDTO = await categoryRepository.GetCategory(request.id);
            if (categoryDTO == null)
            {
                return categoryDTO;
            }

            return categoryDTO;
        }
    }
}
