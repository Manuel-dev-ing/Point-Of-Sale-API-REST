using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
        
        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public string? Correo { get; set; }

        public string? Password { get; set; }

        public bool? Estado { get; set; }
        public DateOnly? FechaCreacion { get; set; }


    }
}
