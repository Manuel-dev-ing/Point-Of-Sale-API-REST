using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class CreateVentaDTO
    {

        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int NumeroVenta { get; set; }
        public int SubTotal { get; set; }
        public int Total { get; set; }

        public IEnumerable<DetalleVentaDTO> DetalleVenta { get; set; }

    }
}
