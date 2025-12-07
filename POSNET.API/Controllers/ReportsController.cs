using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Reports.Queries;

namespace POSNET.API.Controllers
{
    
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("resumeStatistics")]
        public async Task<ReportStatisticsDTO> resumeStatistics()
        {
            var resumeStatistics = await mediator.Send(new GetStatisticsQuery());

            return resumeStatistics;
        }

        [HttpGet("ventasCategorias")]
        public async Task<List<VentasCategoriaDTO>> ventasCategorias()
        {
            var ventasCategorias = await mediator.Send(new GetVentasCategoriasQuery());

            return ventasCategorias;
        }


        [HttpGet("topUsuarios")]
        public async Task<List<TopUsuariosDTO>> TopUsuarios()
        {
            var topUsuarios = await mediator.Send(new GetTopUsuarioQuery());

            return topUsuarios;
        }


        [HttpGet("topProducts")]
        public async Task<List<TopProductsDTO>> topProducts()
        {
            var topProducts = await mediator.Send(new GetTopProductsQuery());

            return topProducts;
        }


        [HttpGet("resumen")]
        public async Task<List<ResumenVentasDTO>> GetResumen(string fechaInicio, string fechaFin)
        {
            var resumenVentas = await mediator.Send(new GetResumenVentasQuery(fechaInicio, fechaFin));


            return resumenVentas;
        }

    }
}
