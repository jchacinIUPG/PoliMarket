using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class DisponibilidadModel
    {
        public int IdBodega { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string? Unidad { get; set; }
        public ProductoModel? Producto { get; set; }
        public BodegaModel? Bodega { get; set; }
    }
}
