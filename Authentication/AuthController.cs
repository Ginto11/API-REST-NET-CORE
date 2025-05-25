using MIAPI.Dtos;
using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MIAPI.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /*INYECTA EL SERVICIO AUTHSERVICE EL CUAL PERMITE USAR CIERTAS UTILIDADES*/
        private readonly AuthService authService;

        /*INYECTA EL SERVICIO USUARIOSERVICE EL CUAL PERMITE LA CONEXION CON LA BASE DE DATOS*/
        private readonly UsuarioService usuarioService;
        public AuthController(AuthService serviceAuth, UsuarioService usuarioService)
        {
            this.authService = serviceAuth;
            this.usuarioService = usuarioService;
        }

        /*METODO QUE PERMITE REGISTRAR USUARIOS*/
        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Registrar(Usuario usuario)
        {
            var usuarioValidarCorreo = await usuarioService.ValidateEmail(usuario.Correo);

            if (usuarioValidarCorreo != null)
                return BadRequest("El correo ya esta registrado.");

            string claveActual = usuario.Clave;

            usuario.Clave = authService.Encriptar(claveActual);

            await usuarioService.Create(usuario);
                  
            return Created();
        }

        /*METODO QUE PERMITE LOGEARSE AL USUARIO*/
        [HttpPost]
        [Route("ingresar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Usuario>> Login(UsuarioLoginDto usuarioLogin)
        {
            var usuarioLogeado = await authService.Authenticate(usuarioLogin);

            if (usuarioLogeado != null)
            {
                //CREAR TOKEN
                var token = authService.GenerarTokenJWT(usuarioLogeado);
                return Ok(token);
            }

            return Unauthorized("Credenciales incorrectas.");
        }


        
    }
}
