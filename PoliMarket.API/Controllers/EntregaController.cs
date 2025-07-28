using Microsoft.AspNetCore.Mvc;
using PoliMarket.API.DTOs;
using PoliMarket.API.Middlewares.Validation;
using PoliMarket.Models;
using PoliMarket.Models.Enums;
using PoliMarket.Services;
using PoliMarket.Services.Interfaces;

namespace PoliMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiresPermission(SistemaEnum.Entregas)]
    public class EntregaController : ControllerBase
    {
        private readonly IVentas _iVentasServices;
        private readonly IBodega _iBodegaServices;

        public EntregaController(IVentas iVentasServices, IBodega iBodegasServices)
        {
            _iVentasServices = iVentasServices;
            _iBodegaServices = iBodegasServices;
        }

        [HttpGet("ConsultarEntregas/{estado}")]
        public IActionResult ConsultarEntregas(string estado)
        {
            try
            {
                var entregas = _iVentasServices.ObtenerEntregas(estado);

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


        [HttpPost, Route("RegistrarSalida")]
        public IActionResult RegistrarSalida([FromBody] EntregaModel entrega)
        {
            try
            {
                bool result = _iBodegaServices.RegistrarSalida(entrega);

                return result
                    ? Ok(new { mensaje = "Salida registrada correctamente." })
                    : NotFound(new { mensaje = "Entrega no encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al registrar la salida." + ex.Message });
            }
        }
    }
}
