using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;


namespace POSNet.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(Categoria categoria);
        Task<List<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int id);
        Task<Categoria> GetCategoryById(int id);
        Task UpdateAsync(Categoria categoria);
    }
}
