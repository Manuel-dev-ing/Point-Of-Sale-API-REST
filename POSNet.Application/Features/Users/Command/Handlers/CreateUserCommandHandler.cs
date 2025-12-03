using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSNet.Application.Common.Exceptions;
using POSNet.Application.Common.Models;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;


namespace POSNet.Application.Features.Users.Command.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<createUserCommand, Result<UserDTO>>
    {
        private readonly IUsersRepository usersRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<Usuario> userManager;

        public CreateUserCommandHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork, UserManager<Usuario> userManager)
        {
            this.usersRepository = usersRepository;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<Result<UserDTO>> Handle(createUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario()
            {
                IdRol = request.idRol,
                Nombre = request.Nombre,
                PrimerApellido = request.PrimerApellido,
                SegundoApellido = request.SegundoApellido,
                Correo = request.Correo,
                Estado = true,
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now)
            };

            var exist = await userManager.FindByEmailAsync(request.Correo);
            if (exist != null)
            {
                throw new DomainException("Correo electrónico ya registrado");
            }
            //await usersRepository.create(usuario);

            //await unitOfWork.CommitAsymc();
            var res = await userManager.CreateAsync(usuario, request.Password);
            if (!res.Succeeded)
            {
                throw new DomainException(string.Join(";", res.Errors.Select(e => e.Description)));
            }                                                                     

            //var userDTO = new UserDTO()
            //{

            //};


            return Result<UserDTO>.OK(new UserDTO
            {
                Id = usuario.Id,
                IdRol = usuario.IdRol,
                Nombre = usuario.Nombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Correo = usuario.Correo,
                Estado = usuario.Estado,
                FechaCreacion = usuario.FechaCreacion
            });
        }
    }
}
