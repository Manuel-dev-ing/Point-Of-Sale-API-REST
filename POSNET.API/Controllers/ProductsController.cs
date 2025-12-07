using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Products.Commands;
using POSNet.Application.Features.Products.Queries;

namespace POSNET.API.Controllers
{
    
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductsDTO>> get()
        {
            var products_dto = await mediator.Send(new GetProductsQuery());

            return products_dto;
        }

        [HttpGet("getAllProducts")]
        public async Task<List<ProductsDTO>> getAllProducts()
        {
            var products_dto = await mediator.Send(new GetProductsQuery());

            return products_dto;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> getProduct(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await mediator.Send(new GetProductQuery(id));

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] CreateProductCommand command)
        {

            var productoDTO = await mediator.Send(command);

            return CreatedAtAction(nameof(getProduct), new { id = productoDTO.Id }, productoDTO);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(int id, [FromBody] UpdateProductCommand command)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var producto = await mediator.Send(command);

            if (producto == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            if (id <= 0) 
            {
                return BadRequest();
            }

            var producto = await mediator.Send(new DeleteProductCommand(id));

            if (producto == null)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
