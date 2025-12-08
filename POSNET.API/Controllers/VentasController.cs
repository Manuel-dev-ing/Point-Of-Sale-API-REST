using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Ventas.Commands;
using POSNet.Application.Features.Ventas.Queries;

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

        [HttpGet("totalVentas")]
        public async Task<int> totalVentas()
        {
            var total = await mediator.Send(new GetTotalVentasQuery());

            return total;
        }


        [HttpPost]
        public async Task<ActionResult> venta([FromBody] CreateVentaCommand command)
        {

            await mediator.Send(command);

            return Ok();
        }



    }
}
