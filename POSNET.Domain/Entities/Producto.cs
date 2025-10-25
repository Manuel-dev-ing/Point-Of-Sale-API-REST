using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class Producto
{
    public int Id { get; set; }

    public int? IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? StockInicial { get; set; }

    public int? StockMinimo { get; set; }

    public string? CodigoBarras { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();



}
