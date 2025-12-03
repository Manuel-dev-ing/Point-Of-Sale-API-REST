using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class RespuestaAutenticacionDTO
    {
        public DateTime expiracion { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }

    }
}
