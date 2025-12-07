using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Categories.Commands;
using POSNet.Application.Features.Categories.Queries;

namespace POSNET.API.Controllers
{
    
    [ApiController]
    [Route("api/categories")]
    
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<List<CategoryDTO>> get()
        {
            var categoriesDTO = await mediator.Send(new GetCategoriesQuery());
            
            return categoriesDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await mediator.Send(new GetCategoryQuery(id));
            if (category == null)
            {
                return NotFound();
            }

            return category;

        }

        [HttpPost]
        public async Task<ActionResult> createCategory([FromBody] CreateCategoryCommand command)
        {

            var category = await mediator.Send(command);
            return CreatedAtAction(nameof(GetCategory), new {id = category.Id}, category);

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            await mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(int id, [FromBody] UpdateCategoryCommand command)
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
