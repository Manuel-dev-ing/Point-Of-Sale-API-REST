using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSNET.Domain.Entities;

public partial class Venta
{
    public int Id { get; set; }

   
    public int? IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public string? NumeroVenta { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Total { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
