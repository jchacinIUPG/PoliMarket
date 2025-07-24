using Microsoft.AspNetCore.Mvc;
using PoliMarket.API.DTOs;
using PoliMarket.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoliMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RHController : ControllerBase
    {
        private readonly IRH _iRHService;

        public RHController(IRH iRHService) 
        {
            _iRHService = iRHService;
        }

        // POST api/<RHController>/Autorizar
        /// <summary>
        /// Autoriza el acceso de un usuario a un sistema definido
        /// </summary>
        /// <param name="auth">Usuario y sistema a autorizar</param>
        /// <returns>True: autorizado, False: no autorizado</returns>
        [HttpPost, Route("Autorizar")]
        public IActionResult Autorizar([FromBody] AuthDTO auth)
        {
            bool result = _iRHService.AutorizarUsuario(auth.NombreUsuario, auth.NombreSistema);
            return result ? Ok() : BadRequest();
        }
    }
}
