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
    public class GetRolsQueryHandler : IRequestHandler<GetRolsQuery, List<RolDTO>>
    {
        private readonly IUsersRepository usersRepository;

        public GetRolsQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public async Task<List<RolDTO>> Handle(GetRolsQuery request, CancellationToken cancellationToken)
        {

            var rolsDTO = await usersRepository.GetRols();

            return rolsDTO;
        }
    }
}
