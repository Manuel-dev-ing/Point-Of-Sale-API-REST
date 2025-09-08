using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNet.Domain.Entities;

namespace POSNet.Application.Features.Categories.Commands.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Categoria()
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now),
                Estado = true
            };

            await categoryRepository.AddAsync(category);
            await unitOfWork.CommitAsymc();

            var categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Nombre = category.Nombre,
                Descripcion = category.Descripcion,
                FechaCreacion = (DateOnly)category.FechaCreacion,
                Estado = (bool)category.Estado,
            };

            return categoryDTO;
        }
    }
}
