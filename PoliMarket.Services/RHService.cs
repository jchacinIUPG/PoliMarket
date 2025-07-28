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
    public class RHService : IRH
    {
        private static List<UsuarioModel>? Usuarios { get; set; }

        public RHService() 
        {
            Usuarios = new List<UsuarioModel> 
            {
                new UsuarioModel { Id = 1, Usuario = "jchacin", Permisos = new List<PermisoModel>() },
                new UsuarioModel { Id = 2, Usuario = "cjimenez", Permisos = new List<PermisoModel>() },
                new UsuarioModel { Id = 2, Usuario = "glopez", Permisos = new List<PermisoModel>() }
            };
        }

        public bool AutorizarUsuario(string nombreUsuario, string nombreSistema)
        {
            var usuario = Usuarios?.Find(u => u.Usuario == nombreUsuario);
            if (usuario != null)
            {
                var sistema = (SistemaEnum)Enum.Parse(typeof(SistemaEnum), nombreSistema);
                var idSistema = (short)sistema;
                if (usuario.Permisos?.Any(p => p.IdSistema == idSistema) == false)
                    usuario.Permisos.Add(new PermisoModel { IdSistema = (short)sistema, IdUsuario = usuario.Id });
                else
                    usuario.Permisos.RemoveAll(p => p.IdSistema == idSistema);

                return true;
            }
            else 
            {
                return false;
            }
        }

        public UsuarioModel? ObtenerUsuario(string nombreUsuario)
        {
            return Usuarios?.Find(u => u.Usuario == nombreUsuario);
        }
    }
}
