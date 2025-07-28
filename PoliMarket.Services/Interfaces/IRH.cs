using PoliMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services.Interfaces
{
    public interface IRH
    {
        bool AutorizarUsuario(string nombreUsuario, string nombreSistema);
        UsuarioModel? ObtenerUsuario(string nombreUsuario);
    }
}
