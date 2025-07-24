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

        // POST api/<RHController>
        /// <summary>
        /// Autoriza el acceso de un usuario a un sistema definido
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AuthDTO auth)
        {
            bool result = _iRHService.AutorizarUsuario(auth.NombreUsuario, auth.NombreSistema);
            return result ? Ok() : BadRequest();
        }
    }
}
