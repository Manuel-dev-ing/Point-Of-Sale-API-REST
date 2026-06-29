using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.DTOs
{
    public class PurchaseHistoryDTO
    {
        public DateOnly Fecha { get; set; }

        public int Items { get; set; }

        public decimal Total { get; set; }
    }
}
