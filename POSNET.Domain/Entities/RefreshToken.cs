using System;
using System.Collections.Generic;

namespace POSNET.Domain.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string? TokenHash { get; set; }

    public DateTime? Expires { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Revoked { get; set; }

    public string? ReplacedByTokenHash { get; set; }

    public string? DeviceInfo { get; set; }
}
