using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateOnly FechaCreacion { get; set; }

        public bool Estado { get; set; }



    }
}
