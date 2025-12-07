using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Proveedores.Commands;
using POSNet.Application.Features.Proveedores.Queries;

namespace POSNET.API.Controllers
{
    
    [ApiController]
    [Route("api/proveedores")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProveedoresController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProveedoresDTO>> get()
        {
            var proveedoresDTO = await mediator.Send(new GetProveedoresQuery());

            return proveedoresDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProveedorDTO>> getProveedor(int id)
        {
            var proveedor = await mediator.Send(new GetProveedorQuery(id));
            if (proveedor == null)
            {
                return NotFound("El Proveedor no existe");
            }


            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] CreateProveedorCommand command)
        {
            var proveedor_dto = await mediator.Send(command);

            return CreatedAtAction(nameof(getProveedor), new { id = proveedor_dto.Id }, proveedor_dto);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var proveedor = await mediator.Send(new DeleteProveedorCommand(id));
            if (proveedor == null)
            {
                return NotFound("El Proveedor no existe");
            }


            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(int id, [FromBody] UpdateProveedorCommand command)
        {

            if (id != command.Id)
            {
                return NotFound("El id de la url no coincide con el id del cuerpo de la solicitud");
            }

            var proveedor = await mediator.Send(command);

            if (proveedor == null)
            {
                return NotFound("El Proveedor no existe");
            }

            return NoContent();
        }

    }
}
