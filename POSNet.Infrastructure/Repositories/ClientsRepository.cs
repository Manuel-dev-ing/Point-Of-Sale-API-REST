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
    public class ClientsRepository : IClientsRepository
    {
        private readonly POSNetDbContext context;

        public ClientsRepository(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task<int> getTotalClients()
        {
            var total = context.Clientes.Count();

            return total;
        }

        public async Task<Cliente> GetClient(int id)
        {
            var client = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            return client;
        }

        public async Task<ClientDTO> GetClientAsync(int id)
        {
            var clientDTO = await context.Clientes
                .Where(x => x.Id == id)
                .Select(x => new ClientDTO()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    Correo = x.Correo,
                    Telefono = x.Telefono,
                    Estado = (bool)x.Estado,
                    HistorialCompras = x.Venta.Select(v => new PurchaseHistoryDTO()
                    {
                        Fecha = (DateOnly)v.Fecha,
                        Total = (decimal)v.Total

                    }).ToList()

                }).FirstOrDefaultAsync();

            return clientDTO;
        }

        public async Task<List<ClientDTO>> GetClientsAsync()
        {
            var clientsDTO = await context.Clientes
                .Where(x => x.Estado == true)
                .Select(x => new ClientDTO()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    Correo = x.Correo,
                    Telefono = x.Telefono,
                    Estado = (bool)x.Estado,
                    HistorialCompras = x.Venta.Select(v => new PurchaseHistoryDTO()
                    {
                        Fecha = (DateOnly)v.Fecha,
                        Items = v.DetalleVenta.Select(x => x.Cantidad).Count(),
                        Total = (decimal)v.Total

                    }).ToList()
                }).ToListAsync();

            return clientsDTO;
        }

        public async Task AddAsync(Cliente cliente)
        {
            context.Clientes.Add(cliente);
        }

       

        public async Task UpdateAsync(Cliente cliente)
        {
            context.Clientes.Update(cliente);
        }

    }
}
