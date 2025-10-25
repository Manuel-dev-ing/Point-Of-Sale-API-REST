using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly POSNetDbContext context;

        public ProductsRepository(POSNetDbContext context)
        {
            this.context = context;
        }


        public async Task<List<ProductsDTO>> GetProducts()
        {
            var productsDTO = await context.Productos
                                    .Include(x => x.IdCategoriaNavigation)
                                    .Where(x => x.Estado == true)
                                    .Select(x => new ProductsDTO()
                                    {
                                        Id = x.Id,
                                        Categoria = x.IdCategoriaNavigation.Nombre,
                                        Nombre = x.Nombre,
                                        Precio = (decimal)x.Precio,
                                        StockInicial = (int)x.StockInicial,
                                        StockMinimo = (int)x.StockMinimo,
                                        CodigoBarras = x.CodigoBarras,
                                        Descripcion = x.Descripcion,
                                        Estado = (bool)x.Estado

                                    }).ToListAsync();
            return productsDTO;

        }

        public async Task<ProductDTO> getProduct(int id)
        {

            var productDTO = await context.Productos
                .Select(x => new ProductDTO()
                {
                    Id = x.Id,
                    IdCategoria = (int)x.IdCategoria,
                    Nombre = x.Nombre,
                    Precio = (decimal)x.Precio,
                    StockInicial = (int)x.StockInicial,
                    StockMinimo = (int)x.StockMinimo,
                    CodigoBarras = x.CodigoBarras,
                    Descripcion = x.Descripcion,
                    Estado = (bool)x.Estado
                }).FirstOrDefaultAsync(x => x.Id == id);

            return productDTO;
        }

        public async Task<Producto> getProductoById(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);

            return producto;
        }

        public async Task guardar(Producto producto)
        {
            context.Productos.Add(producto);

        }

        public async Task update(Producto producto)
        {

            context.Productos.Update(producto);
        }


    }
}
