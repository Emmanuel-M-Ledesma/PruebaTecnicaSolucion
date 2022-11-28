using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
