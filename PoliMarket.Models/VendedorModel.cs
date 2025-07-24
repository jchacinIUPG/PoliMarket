using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class VendedorModel : UsuarioModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Identificacion { get; set; }
        public List<VendedorModel>? Ventas { get; set; }
    }
}
