using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class ResumenVentasDTO
    {
        public decimal Ingresos { get; set; }
        public decimal Ventas { get; set; }
        public DateOnly Fecha { get; set; }

    }
}
