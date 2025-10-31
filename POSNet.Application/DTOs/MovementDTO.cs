using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class MovementDTO
    {

        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdProducto { get; set; }

        public string Tipo { get; set; }

        public int Cantidad { get; set; }

        public string Motivo { get; set; }

        public DateOnly Fecha { get; set; }


    }
}
