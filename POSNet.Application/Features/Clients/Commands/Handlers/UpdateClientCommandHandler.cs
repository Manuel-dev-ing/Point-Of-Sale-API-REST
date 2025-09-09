using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Clients.Commands.Handlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientsRepository clientsRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateClientCommandHandler(IClientsRepository clientsRepository, IUnitOfWork unitOfWork)
        {
            this.clientsRepository = clientsRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await clientsRepository.GetClient(request.Id);
            if (client == null) return;

            client.Nombre = request.Nombre;
            client.PrimerApellido = request.PrimerApellido;
            client.SegundoApellido = request.SegundoApellido;
            client.Correo = request.Correo;
            client.Telefono = request.Telefono;

            await clientsRepository.UpdateAsync(client);
            await unitOfWork.CommitAsymc();

        }
    }
}
