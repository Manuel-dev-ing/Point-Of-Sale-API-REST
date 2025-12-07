using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Movements.Commands;
using POSNet.Application.Features.Movements.Queries;

namespace POSNET.API.Controllers
{
   
    [ApiController]
    [Route("api/inventory")]
    public class MovementController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovementController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<MovementDTO>> GetMovements()
        {
            var movements = await mediator.Send(new GetMovementsQuery());

            return movements;
        }

        [HttpPost]
        public async Task<ActionResult> createMovement([FromBody] CreateMovementCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }



    }
}
