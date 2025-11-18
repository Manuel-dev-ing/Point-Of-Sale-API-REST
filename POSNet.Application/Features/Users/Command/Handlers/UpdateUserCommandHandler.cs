using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POSNet.Application.Features.Users.Command.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsersRepository usersRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUsersRepository usersRepository)
        {
            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await unitOfWork.BeginTransactionAsync();
                var user = await usersRepository.GetUserById(request.id);
                var usuario = new Usuario()
                {
                    Id = user.Id,
                    IdRol = request.idRol,
                    Nombre = request.Nombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    Correo = request.Correo,
                    Estado = request.Estado
                };

                await usersRepository.update(usuario);

                await unitOfWork.CommitAsymc();
            }
            catch 
            {

                await unitOfWork.RollbackAsync();

            }

        }
    }
}
