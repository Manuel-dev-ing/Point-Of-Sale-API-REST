using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;

namespace POSNet.Infrastructure.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly POSNetDbContext context;

        public ReportsRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<List<VentasCategoriaDTO>> GetVentasCategorias()
        {
            var ventasCategoria = await context.Ventas
                .SelectMany(v => v.DetalleVenta)
                .GroupBy(d => d.IdProductoNavigation.IdCategoriaNavigation.Nombre)
                .Select(g => new VentasCategoriaDTO
                {
                    Value = g.Sum(x => x.IdVentaNavigation.Total) ?? 0m,
                    Categoria = g.Key

                })
                .OrderByDescending(x => x.Value)
                .ToListAsync();

            return ventasCategoria;
        }

        public async Task<List<TopUsuariosDTO>> GetTopUsuarios()
        {
            var topUsuarios = await context.Ventas
                    .Where(v => v.IdUsuario != null)
                    .GroupBy(v => new { v.IdUsuarioNavigation!.Nombre, v.IdUsuarioNavigation.PrimerApellido })
                    .Select(g => new TopUsuariosDTO
                    {
                        Nombre = g.Key.Nombre,
                        PrimerApellido = g.Key.PrimerApellido,
                        Ventas = g.Count(),
                        Total = g.Sum(v => v.Total) ?? 0m

                    })
                    .OrderByDescending(x => x.Total)
                    .Take(5)
                    .ToListAsync();

            return topUsuarios;
        }

        public async Task<List<TopProductsDTO>> GetTopProducts()
        {

            var topProducts = await context.DetalleVenta
                .GroupBy(d => new { d.IdProductoNavigation.Id, d.IdProductoNavigation.Nombre })
                .Select(g => new TopProductsDTO
                {
                    IdProducto = g.Key.Id,
                    Nombre = g.Key.Nombre,
                    Cantidad = (int)g.Sum(x => x.Cantidad),
                    Ingresos = (int)g.Sum(x => x.Total)
                })
                .OrderByDescending(x => x.Cantidad)
                .Take(5)
                .ToListAsync();

            return topProducts;
        }

        public async Task<List<ResumenVentasDTO>> ResumenVentasAsync(string fechaInicio, string fechaFin)
        {

            if (!DateOnly.TryParse(fechaInicio, out var inicio))
                throw new ArgumentException("fechaInicio no tiene un formato válido.", nameof(fechaInicio));

            if (!DateOnly.TryParse(fechaFin, out var fin))
                throw new ArgumentException("fechaFin no tiene un formato válido.", nameof(fechaFin));

            var resumenVentas = await context.Ventas
                .Where(x => x.Fecha >= inicio && x.Fecha <= fin)
                .GroupBy(x => x.Fecha)
                .Select(g => new ResumenVentasDTO()
                {
                    
                    Ingresos = (decimal)g.Sum(x => x.Total),
                    Ventas = (decimal)g.Sum(x => x.Total),
                    Fecha = (DateOnly)g.Key
                }).ToListAsync();


            return resumenVentas;
        }
        
    }
}
