using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class UsuarioRol
{
    public int IdRol { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
