using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;

namespace POSNet.Application.Features.Movements.Queries.Handlers
{
    public class GetMovementsQueryHandler : IRequestHandler<GetMovementsQuery, List<MovementDTO>>
    {
        private readonly IMovementRepository movementRepository;

        public GetMovementsQueryHandler(IMovementRepository movementRepository)
        {
            this.movementRepository = movementRepository;
        }


        public async Task<List<MovementDTO>> Handle(GetMovementsQuery request, CancellationToken cancellationToken)
        {

            var movementDTO = await movementRepository.GetMovements();

            return movementDTO;
        }
    }
}
