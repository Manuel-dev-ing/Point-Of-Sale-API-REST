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
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly IUsersRepository usersRepository;

        public GetUsersQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public async Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await usersRepository.GetUsers();

            return users;
        }
    }
}
