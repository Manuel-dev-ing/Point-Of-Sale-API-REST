using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class profileDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public List<RolDTO> Roles { get; set; }


    }
}
