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
    public class ProveedoresRepository : IProveedoresRepository
    {
        private readonly POSNetDbContext context;

        public ProveedoresRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ProveedoresDTO>> GetProveedoresAsync()
        {
            var proveedoresDTO = await context.Proveedores
                                        .Include(x => x.IdCiudadNavigation)
                                        .Where(x => x.Estado == true)
                                        .Select(x => new ProveedoresDTO()
                                        {
                                            Id = x.Id,
                                            Ciudad = x.IdCiudadNavigation.Nombre,
                                            Nombre = x.Nombre,
                                            PrimerApellido = x.PrimerApellido,
                                            SegundoApellido = x.SegundoApellido,
                                            Correo = x.Correo,
                                            Telefono = x.Telefono,
                                            Colonia = x.Colonia,
                                            CodigoPostal = x.CodigoPostal,
                                            Estado = (bool)x.Estado

                                        }).ToListAsync();
            return proveedoresDTO;

        }

        public async Task<ProveedorDTO> GetProveedor(int id)
        {
            var proveedor = await context.Proveedores
                .Select(x => new ProveedorDTO()
                {
                    Id = x.Id,
                    IdCiudad = (int)x.IdCiudad,
                    Nombre = x.Nombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    Correo = x.Correo,
                    Telefono = x.Telefono,
                    Colonia = x.Colonia,
                    CodigoPostal = x.CodigoPostal,
                    Estado = (bool)x.Estado
                })
                .FirstOrDefaultAsync(x => x.Id == id && x.Estado == true);

            return proveedor;
        }

        public async Task<Proveedore> GetProveedorId(int id)
        {
            var proveedor = await context.Proveedores
               .FirstOrDefaultAsync(x => x.Id == id && x.Estado == true);

            return proveedor;
        }

        public async Task AddAsync(Proveedore proveedore)
        {
            context.Proveedores.Add(proveedore);
        }

        public async Task UpdateAsync(Proveedore proveedore)
        {
            context.Proveedores.Update(proveedore);
        }

    }
}
