using MIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MIAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public Task<Usuario> Get()
        {
            var usuario = new Usuario { Nombre = "Camilo", Clave ="123", Correo ="x@gmail.com" };
            return usuario;
        }
    }
}
