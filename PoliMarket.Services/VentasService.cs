using PoliMarket.Models;
using PoliMarket.Models.Enums;
using PoliMarket.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services
{
    public class VentasService : IVentas
    {
        private static List<VentasModel>? Ventas { get; set; }

        public VentasService() 
        {
            Ventas = new List<VentasModel>();
        }

        public bool RegistrarVenta(VentasModel venta)
        {
            try
            {
                Ventas?.Add(venta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EntregaModel> ObtenerEntregas(string estado)
        {
            var estadoEntrega = (EstadoEntregaEnum)Enum.Parse(typeof(EstadoEntregaEnum), estado);
            return Ventas?.FindAll(v => v.Entrega.Estado.Equals(estadoEntrega)).Select(v => v.Entrega).ToList();
        }

        public VentasModel ObtenerVentaPorId(long idVenta)
        {
            return Ventas?.Find(v => v.Id == idVenta);
        }
    }
}
