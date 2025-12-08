using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSNet.Application.Common.Exceptions;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POSNet.Application.Features.Users.Command.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsersRepository usersRepository;
        private readonly UserManager<Usuario> userManager;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUsersRepository usersRepository, UserManager<Usuario> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.usersRepository = usersRepository;
            this.userManager = userManager;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await unitOfWork.BeginTransactionAsync();
                var user = await usersRepository.FindByIdAsync(request.id);
                user.Nombre = request.Nombre;
                user.PrimerApellido = request.PrimerApellido;
                user.SegundoApellido = request.SegundoApellido;
                user.Correo = request.Correo;
                user.Estado = request.Estado;
                //user.Password = request.Password;


                //await usersRepository.update(usuario);

                //await unitOfWork.CommitAsymc();
                await userManager.RemovePasswordAsync(user);
                await userManager.AddPasswordAsync(user, request.Password);
                //await userManager.ChangePasswordAsync(user, user.Password, request.Password);
                var res = await userManager.UpdateAsync(user);
                if (!res.Succeeded)
                {
                    throw new DomainException(string.Join(";", res.Errors.Select(e => e.Description)));
                }
            }
            catch 
            {

                await unitOfWork.RollbackAsync();

            }

        }

        //private string hashPassword(string password)
        //{
        //    using var sha = SHA256.Create();
        //    var bytes = Encoding.UTF8.GetBytes(password);
        //    var hash = sha.ComputeHash(bytes);
        //    return Convert.ToBase64String(hash);
        //}
    }
}
