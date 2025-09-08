using System;
using System.Collections.Generic;

namespace POSNet.Domain.Entities;

public partial class Movimiento
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdProducto { get; set; }

    public string? Tipo { get; set; }

    public int? Cantidad { get; set; }

    public string? Motivo { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
