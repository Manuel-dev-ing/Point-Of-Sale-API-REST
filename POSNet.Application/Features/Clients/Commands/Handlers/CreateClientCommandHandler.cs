using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNET.Domain.Entities;


namespace POSNet.Application.Features.Clients.Commands.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientDTO>
    {
        private readonly IClientsRepository clientsRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateClientCommandHandler(IClientsRepository clientsRepository, IUnitOfWork unitOfWork)
        {
            this.clientsRepository = clientsRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<ClientDTO> Handle(CreateClientCommand cliente, CancellationToken cancellationToken)
        {
            var client = new Cliente()
            {
                Nombre = cliente.Nombre,
                PrimerApellido = cliente.PrimerApellido,
                SegundoApellido = cliente.SegundoApellido,
                Correo = cliente.Correo,
                Telefono = cliente.Telefono,
                Estado = true
            };

            await clientsRepository.AddAsync(client);
            await unitOfWork.CommitAsymc();

            var clienteDTO = new ClientDTO()
            {
                Id = client.Id,
                Nombre = client.Nombre,
                PrimerApellido = client.PrimerApellido,
                SegundoApellido = client.SegundoApellido,
                Correo = cliente.Correo,
                Telefono = client.Telefono,
                Estado = (bool)client.Estado
            };

            return clienteDTO;
        }
    }
}
