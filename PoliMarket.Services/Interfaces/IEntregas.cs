using PoliMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services.Interfaces
{
    public interface IEntregas
    {
        List<EntregaModel> ObtenerEntregas(string estado);

        bool RegistrarSalida(EntregaModel entrega);

    }
}
