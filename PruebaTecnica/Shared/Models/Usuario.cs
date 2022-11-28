using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int IdProveedor { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
