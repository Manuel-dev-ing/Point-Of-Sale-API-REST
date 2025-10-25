using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IProductsRepository
    {
        Task<ProductDTO> getProduct(int id);
        Task<Producto> getProductoById(int id);
        Task<List<ProductsDTO>> GetProducts();
        Task guardar(Producto producto);
        Task update(Producto producto);
    }
}
