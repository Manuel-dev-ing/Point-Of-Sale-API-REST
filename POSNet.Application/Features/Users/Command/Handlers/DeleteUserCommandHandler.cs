using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Users.Command.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsersRepository usersRepository;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IUsersRepository usersRepository)
        {
            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await unitOfWork.BeginTransactionAsync();
                var user = await usersRepository.GetUserById(request.id);
                var usuario = new Usuario()
                {
                    Id = user.Id,
                    IdRol = user.IdRol,
                    Nombre = user.Nombre,
                    PrimerApellido = user.PrimerApellido,
                    SegundoApellido = user.SegundoApellido,
                    Correo = user.Correo,
                    Estado = false
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
