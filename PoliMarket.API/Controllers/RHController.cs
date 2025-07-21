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

        // GET: api/<RHController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RHController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RHController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthDTO auth)
        {
            bool result = await _iRHService.AutorizarUsuario(auth.NombreUsuario, auth.NombreSistema);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<RHController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RHController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
