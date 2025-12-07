using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IRolRepository
    {
        Task<Rol> GetRolByName(string name);
    }
}
