using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int StockInicial { get; set; }

        public int StockMinimo { get; set; }

        public string CodigoBarras { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }


    }
}
