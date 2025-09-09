using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Clients.Queries.Handlers
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDTO>
    {
        private readonly IClientsRepository clientsRepository;

        public GetClientQueryHandler(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }

        public async Task<ClientDTO> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var clientDTO = await clientsRepository.GetClientAsync(request.id);



            return clientDTO;
        }
    }
}
