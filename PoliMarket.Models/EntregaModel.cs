using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class EntregaModel
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public string? Entregado { get; set; }
        public List<ProductoModel>? Productos { get; set; }
    }
}
