using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class TopUsuariosDTO
    {

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public int Ventas { get; set; }
        public decimal Total { get; set; }

    }
}
