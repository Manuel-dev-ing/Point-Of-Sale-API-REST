using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.Features.Compras.Commands;

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


        [HttpPost]
        public async Task<ActionResult> post([FromBody] CreateCompraCommand command)
        {
            await mediator.Send(command);

            return Ok();
        }



    }
}
