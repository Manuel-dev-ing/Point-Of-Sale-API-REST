using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class ReportStatisticsDTO
    {

        public int Ventas { get; set; }
        public decimal Ingresos { get; set; }
        public int UnidadesTotales { get; set; }
        public int ValorInventario { get; set; }
    }
}
