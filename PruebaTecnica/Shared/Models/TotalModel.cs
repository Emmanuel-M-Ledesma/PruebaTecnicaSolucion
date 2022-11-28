using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.Models
{
    public class TotalModel
    {
        public List<Pedido> pedidos { get; set; }
        public decimal? SumaTotal { get; set; }
        public decimal? ComisionProveedor { get; set; }
    }
}
