using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Categories.Commands.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await categoryRepository.GetCategoryById(request.id);

            if (category == null)
            {
                return;
            }

            category.Estado = false;
            await categoryRepository.UpdateAsync(category);
            await unitOfWork.CommitAsymc();

        }
    }
}
