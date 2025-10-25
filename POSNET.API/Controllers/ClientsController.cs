using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Clients.Commands;
using POSNet.Application.Features.Clients.Queries;
using POSNet.Application.Features.Products.Queries;

namespace POSNET.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ClientDTO>> get()
        {
            var clientsDTO = await mediator.Send(new GetClientsQuery());

            return clientsDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ClientDTO> GetClient(int id)
        {
            var client = await mediator.Send(new GetClientQuery(id));

            return client;
        }

        [HttpGet("getAllClients")]
        public async Task<List<ClientDTO>> getAllClients()
        {
            var clientsDTO = await mediator.Send(new GetClientsQuery());

            return clientsDTO;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] CreateClientCommand command)
        {

            var client = await mediator.Send(command);

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            await mediator.Send(new DeleteClientCommand(id));

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(int id, UpdateClientCommand command)
        {
            if (id != command.Id)
            {
                return NotFound("El id de la url no coincide con el id del cuerpo de la solicitud");
            }

            await mediator.Send(command);

            return NoContent();
        }


    }
}
