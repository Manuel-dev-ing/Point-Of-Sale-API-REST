using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
