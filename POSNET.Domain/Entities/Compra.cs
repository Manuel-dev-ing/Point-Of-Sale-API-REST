using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class Compra
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdProveedor { get; set; }

    public string? NumeroCompra { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Total { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
