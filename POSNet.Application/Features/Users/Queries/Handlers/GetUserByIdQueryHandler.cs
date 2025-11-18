using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Users.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUsersRepository usersRepository;

        public GetUserByIdQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await usersRepository.GetUserById(request.id);

            return user;

        }
    }
}
