using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class ProveedorDTO
    {
        public int Id { get; set; }

        public int IdCiudad { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Colonia { get; set; }

        public string CodigoPostal { get; set; }

        public bool Estado { get; set; }

    }
}
