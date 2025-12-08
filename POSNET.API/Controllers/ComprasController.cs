using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.Features.Compras.Commands;
using POSNet.Application.Features.Compras.Queries;
using POSNet.Application.Features.Ventas.Queries;

namespace POSNET.API.Controllers
{
    
    [ApiController]
    [Route("api/compras")]
    public class ComprasController : ControllerBase
    {
        private readonly IMediator mediator;

        public ComprasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("totalCompras")]
        public async Task<int> totalCompras()
        {
            var total = await mediator.Send(new GetComprasQuery());

            return total;
        }


        [HttpPost]
        public async Task<ActionResult> post([FromBody] CreateCompraCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }



    }
}
