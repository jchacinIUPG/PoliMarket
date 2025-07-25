using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class VentasModel
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdVendedor { get; set; }
        public string? IdCliente { get; set; }
        public VendedorModel? Vendedor { get; set; }
        public ClienteModel? Cliente { get; set; }
        public List<DetalleVentaModel>? Detalles { get; set; }
        public EntregaModel? Entrega { get; set; }
    }
}
