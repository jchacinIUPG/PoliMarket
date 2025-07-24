using Microsoft.AspNetCore.Mvc;
using PoliMarket.API.DTOs;
using PoliMarket.Models;
using PoliMarket.Services;
using PoliMarket.Services.Interfaces;

namespace PoliMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly IEntregas _iEntregasServices;

        public EntregaController(IEntregas iEntregasServices)
        {
            _iEntregasServices = iEntregasServices;
        }


        [HttpGet("Entregas/Estado/{estado}")]
        public IActionResult Autorizar([FromBody] string estado)
        {
           var entregas = _iEntregasServices.ObtenerEntregas(estado);

            return entregas.Any() ? Ok(entregas) : NotFound("No se encontraron entregas.");
        }

        [HttpPost, Route("Entregas/RegistrarSalida")]
        public IActionResult RegistrarSalida([FromBody] EntregaModel entrega)
        {
            try
            {
                bool result = _iEntregasServices.RegistrarSalida(entrega);

                return result
                    ? Ok(new { mensaje = "Salida registrada correctamente." })
                    : NotFound(new { mensaje = "Entrega no encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al registrar la salida.", detalle = ex.Message });
            }
        }
    }
}
