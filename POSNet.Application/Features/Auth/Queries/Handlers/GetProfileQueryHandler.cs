using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSNet.Application.Common.Exceptions;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Auth.Queries.Handlers
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, profileDTO>
    {
        private readonly IUsersRepository usersRepository;

        public GetProfileQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<profileDTO> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetProfile(request.email);
            if (user == null)
            {
                throw new DomainException("No se encontro la informacion del usuario.");
            }


            return user;
        }
    }
}
