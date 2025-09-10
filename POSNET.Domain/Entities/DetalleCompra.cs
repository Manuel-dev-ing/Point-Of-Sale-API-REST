using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class DetalleCompra
{
    public int Id { get; set; }

    public int? IdCompra { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
