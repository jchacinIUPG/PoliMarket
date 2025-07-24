using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class ClienteModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Identificacion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public List<VendedorModel>? Compras { get; set; }
    }
}
