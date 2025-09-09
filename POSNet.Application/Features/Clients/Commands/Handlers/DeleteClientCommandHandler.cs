using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Clients.Commands.Handlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientsRepository clientsRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteClientCommandHandler(IClientsRepository clientsRepository, IUnitOfWork unitOfWork)
        {
            this.clientsRepository = clientsRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await clientsRepository.GetClient(request.id);
            client.Estado = false;

            await clientsRepository.UpdateAsync(client);

            await unitOfWork.CommitAsymc();

        }
    }
}
