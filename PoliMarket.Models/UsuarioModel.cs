using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }

        public List<PermisoModel>? Permisos { get; set; }
    }
}
