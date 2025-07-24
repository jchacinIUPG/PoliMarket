using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Models
{
    public class BodegaModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Capacidad { get; set; }
        public List<DisponibilidadModel>? Productos { get; set; }
    }
}
