using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;

namespace POSNet.Application.Features.Users.Command.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<createUserCommand, UserDTO>
    {
        private readonly IUsersRepository usersRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateUserCommandHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            this.usersRepository = usersRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Handle(createUserCommand request, CancellationToken cancellationToken)
        {

            var usuario = new Usuario()
            {
                IdRol = request.idRol,
                Nombre = request.Nombre,
                PrimerApellido = request.PrimerApellido,
                SegundoApellido = request.SegundoApellido,
                Correo = request.Correo,
                Estado = true
            };

            await usersRepository.create(usuario);

            await unitOfWork.CommitAsymc();

            var userDTO = new UserDTO()
            {
                Id = usuario.Id,
                IdRol = usuario.IdRol,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Correo = usuario.Correo,    
                Estado = usuario.Estado
            };

            return userDTO;
            


        }
    }
}
