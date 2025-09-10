using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
