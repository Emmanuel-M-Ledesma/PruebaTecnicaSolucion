using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Calle { get; set; } = null!;

    public int Numero { get; set; }

    public string Localidad { get; set; } = null!;

    public int IdProvincia { get; set; }

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual ICollection<ProvSuc> ProvSucs { get; } = new List<ProvSuc>();
}
