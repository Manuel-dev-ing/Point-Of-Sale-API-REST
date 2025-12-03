using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using POSNet.Application.Features.Users.Command;

namespace POSNet.Application.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<createUserCommand>
    {

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El password es obligatorio.");
        
        }


    }
}
