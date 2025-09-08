using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSNet.Application.DTOs;
using POSNet.Application.Interfaces;
using POSNet.Domain.Entities;
using POSNet.Infrastructure.Persistence;

namespace POSNet.Infrastructure.Repositories
{
    public class CategorieRepository : ICategoryRepository
    {
        private readonly POSNetDbContext context;

        public CategorieRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<Categoria> GetCategoryById(int id)
        {

            var category = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }


        public async Task<CategoryDTO> GetCategory(int id)
        {
            var categoryDTO = await context.Categorias.Select(x => new CategoryDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                FechaCreacion = (DateOnly)x.FechaCreacion,
                Estado = (bool)x.Estado

            }).FirstOrDefaultAsync(x => x.Id == id);

            return categoryDTO;
        }


        public async Task<List<CategoryDTO>> GetCategories()
        {
            var categories = await context.Categorias
                .Where(x => x.Estado == true)
                .Select(x => new CategoryDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Estado = (bool)x.Estado,
                FechaCreacion = (DateOnly)x.FechaCreacion

            }).ToListAsync();

            return categories;
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            context.Categorias.Update(categoria);
        }

        public async Task AddAsync(Categoria categoria)
        {
            context.Categorias.Add(categoria);
        }

    }
}
