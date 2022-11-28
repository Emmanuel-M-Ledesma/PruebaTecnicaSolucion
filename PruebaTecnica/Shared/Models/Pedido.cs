using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdProveedor { get; set; }

    public int? IdSucursal { get; set; }

    public int IdEstado { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Monto { get; set; }

    public virtual ProvSuc? Id { get; set; }

    public virtual EstadoPedido IdEstadoNavigation { get; set; } = null!;
}
