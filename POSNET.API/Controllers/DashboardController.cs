using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Dashboard.Queries;

namespace POSNET.API.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator mediator;

        public DashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<ResumenDashboardDTO>> get()
        {
            var resumeDashboard = await mediator.Send(new GetResumeDashboardQuery());

            return resumeDashboard;
        }

        [HttpGet("GetLowStockProducts")]
        public async Task<List<ProductDTO>> GetLowStockProducts()
        {
            var products = await mediator.Send(new GetLowStockProductsQuery());

            return products;
        }


    }
}
