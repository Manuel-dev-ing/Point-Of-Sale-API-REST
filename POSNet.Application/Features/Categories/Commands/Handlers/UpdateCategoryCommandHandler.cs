using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Categories.Commands.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryById(request.Id);
            category.Nombre = request.Nombre;
            category.Descripcion = request.Descripcion;
            category.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);

            await categoryRepository.UpdateAsync(category);
            await unitOfWork.CommitAsymc();


        }
    }
}
