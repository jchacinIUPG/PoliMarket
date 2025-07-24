using Microsoft.AspNetCore.Mvc;
using PoliMarket.Models;
using PoliMarket.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoliMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IBodega _iBodega;
        private readonly IVentas _iVentas;

        public VentasController(IBodega iBodega, IVentas iVentas) 
        {
            _iBodega = iBodega;
            _iVentas = iVentas;
        }

        // GET: api/<VentasController>/ObtenerProductos
        /// <summary>
        /// Obtiene los productos disponibles en bodega
        /// </summary>
        /// <returns>Lista de productos disponibles</returns>
        [HttpGet, Route("ObtenerProductos")]
        public List<DisponibilidadModel> ObtenerProductos()
        {
            return _iBodega.ProductosDisponibles();
        }

        // POST api/<VentasController>/RegistrarVenta
        /// <summary>
        /// Registra la venta realizada por un vendedor
        /// </summary>
        /// <param name="venta">Datos de la venta</param>
        /// <returns>True: registro exitoso, False: registro fallido</returns>
        [HttpPost, Route("RegistrarVenta")]
        public IActionResult RegistrarVenta([FromBody] VentasModel venta)
        {
            bool result = _iVentas.RegistrarVenta(venta);
            return result ? Ok() : BadRequest();
        }
    }
}
