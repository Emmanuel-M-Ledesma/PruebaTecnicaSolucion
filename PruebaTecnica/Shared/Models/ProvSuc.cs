using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class ProvSuc
{
    public int IdProveedor { get; set; }

    public int IdSucursal { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
