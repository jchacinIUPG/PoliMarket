using PoliMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services.Interfaces
{
    public interface IVentas
    {
        bool RegistrarVenta(VentasModel venta);
        VentasModel ObtenerVentaPorId(long idVenta);

    }
}
