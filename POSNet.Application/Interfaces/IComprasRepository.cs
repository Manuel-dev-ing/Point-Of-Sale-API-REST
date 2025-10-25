using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNET.Domain.Entities;

namespace POSNet.Application.Interfaces
{
    public interface IComprasRepository
    {
        Task createCompra(Compra compra);
    }
}
