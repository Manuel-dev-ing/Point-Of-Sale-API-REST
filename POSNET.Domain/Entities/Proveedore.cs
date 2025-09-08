using System;
using System.Collections.Generic;

namespace POSNet.Domain.Entities;

public partial class Proveedore
{
    public int Id { get; set; }

    public int? IdCiudad { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Colonia { get; set; }

    public string? CodigoPostal { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
