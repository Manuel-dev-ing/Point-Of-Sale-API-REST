using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Reports.Queries;
using POSNet.Application.Features.Users.Command;
using POSNet.Application.Features.Users.Queries;

namespace POSNET.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("getRols")]
        public async Task<List<RolDTO>> getRols()
        {
            var rolDTOS = await mediator.Send(new GetRolsQuery());

            return rolDTOS;
        }

        [HttpGet]
        public async Task<List<UserDTO>> get()
        {
            var users = await mediator.Send(new GetUsersQuery());

            return users;
        }

        [HttpGet("{id:int}")]
        public async Task<UserDTO> getUserById(int id)
        {
            var user = await mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                return null;
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] createUserCommand command)
        {

            var user = await mediator.Send(command);

            return CreatedAtAction(nameof(getUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(int id ,[FromBody] UpdateUserCommand command)
        {

            if (id != command.id)
            {
                return NotFound("El id de la url no coincide con el id del cuerpo de la solicitud");
            }
            await mediator.Send(command);

            return NoContent();

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            await mediator.Send(new DeleteUserCommand(id));

            return NoContent();
        }

    }
}
