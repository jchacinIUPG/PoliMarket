using PoliMarket.Models;
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
    }
}
