using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly POSNetDbContext context;

        public RolRepository(POSNetDbContext context)
        {
            this.context = context;
        }


        public async Task<Rol> GetRolByName(string name)
        {
            var role = await context.Rols.FirstOrDefaultAsync(x => x.Nombre == name);

            return role;
        }





    }
}
