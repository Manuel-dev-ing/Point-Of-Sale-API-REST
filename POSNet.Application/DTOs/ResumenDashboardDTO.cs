using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class ResumenDashboardDTO
    {

        public int ventas { get; set; }
        public decimal ingresos { get; set; }
        public int productos { get; set; }
        public int clientes { get; set; }

    }
}
