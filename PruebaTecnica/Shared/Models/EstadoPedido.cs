using System;
using System.Collections.Generic;

namespace PruebaTecnica.Shared.Models;

public partial class EstadoPedido
{
    public int IdEstado { get; set; }

    public string TipoEstado { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
