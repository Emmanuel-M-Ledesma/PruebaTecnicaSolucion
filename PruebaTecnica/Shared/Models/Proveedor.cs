using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public int Comision { get; set; }

    public virtual ICollection<ProvSuc> ProvSucs { get; } = new List<ProvSuc>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
