using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class Ciudade
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();
}
