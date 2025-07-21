using PoliMarket.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services
{
    public class RHService : IRH
    {
        public Task<bool> AutorizarUsuario(string nombreUsuario, string nombreSistema)
        {
            throw new NotImplementedException();
        }
    }
}
