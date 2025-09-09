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
    public class ListClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientDTO>>
    {
        private readonly IClientsRepository clientsRepository;

        public ListClientsQueryHandler(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }
        public async Task<List<ClientDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {

            var clients = await clientsRepository.GetClientsAsync();

            return clients; 
        }
    }
}
