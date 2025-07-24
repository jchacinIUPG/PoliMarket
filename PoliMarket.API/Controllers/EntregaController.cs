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
        public IActionResult ConsultarEntregas(string estado)
        {
            try
            {
                var entregas = _iEntregasServices.ObtenerEntregas(estado);

                if (entregas == null || !entregas.Any())
                    return NotFound(new { mensaje = "No se encontraron entregas con el estado especificado." });

                return Ok(entregas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Ocurrió un error al consultar las entregas.",
                    detalle = ex.Message
                });
            }
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
