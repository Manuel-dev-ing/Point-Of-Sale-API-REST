using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using POSNet.Application.Features.Categories.Commands;


namespace POSNet.Application.Validations
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.");
            RuleFor(x => x.Descripcion)
                .MaximumLength(250).WithMessage("La descripcion no debe superar los 250 caracteres.");


        }



    }
}
