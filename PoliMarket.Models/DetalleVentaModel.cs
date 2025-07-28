using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class DetalleVentaModel
    {
        public short Unidades { get; set; }
        public int IdProducto { get; set; }
        public ProductoModel? Producto { get; set; }
    }
}
