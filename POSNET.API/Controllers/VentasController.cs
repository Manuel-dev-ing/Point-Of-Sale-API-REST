using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Ventas.Commands;

namespace POSNET.API.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController : ControllerBase
    { 
        private readonly IMediator mediator;

        public VentasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> venta([FromBody] CreateVentaCommand command)
        {

            await mediator.Send(command);

            return Ok();
        }



    }
}
