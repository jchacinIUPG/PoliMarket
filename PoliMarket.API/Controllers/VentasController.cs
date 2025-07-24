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

        public VentasController(IBodega iBodega) 
        {
            _iBodega = iBodega;
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
    }
}
