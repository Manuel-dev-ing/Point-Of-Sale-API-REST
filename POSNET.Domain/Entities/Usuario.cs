using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSNET.Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public bool? Estado { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
