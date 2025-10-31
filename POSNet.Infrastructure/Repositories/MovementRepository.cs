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
    public class MovementRepository : IMovementRepository
    {
        private readonly POSNetDbContext context;

        public MovementRepository(POSNetDbContext context)
        {
            this.context = context;
        }
        
        public async Task<List<MovementDTO>> GetMovements()
        {

            var movements = await context.Movimientos.Select(x => new MovementDTO()
            {
                Id = x.Id,
                IdUsuario = (int)x.IdUsuario,
                IdProducto = (int)x.IdProducto,
                Tipo = x.Tipo,
                Cantidad = (int)x.Cantidad,
                Motivo = x.Motivo,
                Fecha = (DateOnly)x.Fecha

            }).ToListAsync();

            return movements;

        }

        public async Task crear(Movimiento movimiento)
        {

            context.Movimientos.Add(movimiento);

        }



    }
}
