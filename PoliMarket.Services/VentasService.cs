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
                venta.Id = Ventas.Count > 0 ? Ventas.Max(v => v.Id) + 1 : 1;
                venta.Entrega = new EntregaModel 
                {
                    IdVenta = venta.Id.Value,
                    Estado = EstadoEntregaEnum.Pendiente,
                    Productos = venta.Detalles?.Select(d => d.Producto).ToList()
                };

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
            try
            {
                var estadoEntrega = (EstadoEntregaEnum)Enum.Parse(typeof(EstadoEntregaEnum), estado);
                return Ventas?.FindAll(v => v.Entrega.Estado.Equals(estadoEntrega)).Select(v => v.Entrega).ToList();

            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"El estado '{estado}' no es válido. Usa valores como: {string.Join(", ", Enum.GetNames(typeof(EstadoEntregaEnum)))}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener las entregas", ex);
            }
        }

        public VentasModel ObtenerVentaPorId(long idVenta)
        {
            return Ventas?.FirstOrDefault(v => v.Id == idVenta);
        }
    }
}
