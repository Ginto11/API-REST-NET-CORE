using MIAPI.Authentication;
using MIAPI.Dtos;
using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MIAPI.Controllers
{
    [Route("api/usuarios")]
    [Authorize(Roles = "Administrador")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /*INYECTA EL SERVICIO AuthService EL CUAL PERMITE USAR CIERTAS UTILIDADES*/
        private readonly AuthService authService;

        /*INYECTA EL SERVICIO UsuarioService EL CUAL PERMITE LA CONEXION CON LA BASE DE DATOS*/
        private readonly UsuarioService usuarioService;
        public UsuarioController(UsuarioService usuarioService, AuthService authService)
        {
            this.usuarioService = usuarioService;
            this.authService = authService;
        }

        /*METODO QUE REGRESA UNA LISTA DE USUARIOS*/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await usuarioService.GetAll();
        }

        /*METODO QUE PERMITE BUSCAR UN USUARIO POR ID*/
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> BuscarUsuario(int id)
        {
            try { 
            
                var usuarioBuscado = await usuarioService.GetById(id);

                if (usuarioBuscado == null)
                    return NotFound($"El usuario Nº {id}, no existe.");

                return usuarioBuscado;

            } catch (Exception e) {
                return StatusCode(500, $"Error: {e.Message}");
            }

        }

        /*METODO QUE PERMITE CREAR UN NUEVO USUARIO*/
        [HttpPost]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> AgregarUsuario(Usuario usuario)
        {
            var usuarioValidarCorreo = await usuarioService.ValidateEmail(usuario.Correo);

            if (usuarioValidarCorreo != null)
                return BadRequest("El correo ya esta registrado.");

            string claveActual = usuario.Clave;

            usuario.Clave = authService.Encriptar(claveActual);

            var usuarioNuevo = await usuarioService.Create(usuario);
            return Ok(usuarioNuevo);
        }

        /*METODO QUE PERMITE ACTUALIZAR USUARIO*/
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ActualizarUsuario(Usuario usuario, int id)
        {
            if(usuario.Id != id)
                return BadRequest($"Error: El ID({id}) de la URL, no coincide con el ID({usuario.Id}) del usuario.");
            
            var usuarioPorActualizar = await usuarioService.GetById(usuario.Id);

            if (usuarioPorActualizar == null)
                return NotFound($"El usuario Nº {usuario.Id}, no existe.");

            await usuarioService.Update(usuarioPorActualizar);
            return NoContent();

        }

        /*METODO QUE PERMITE ELIMINAR UN USUARIO*/
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var usuarioPorEliminar = await usuarioService.GetById(id);

            if(usuarioPorEliminar == null)
                return NotFound($"El usuario Nº {id}, no existe.");

            await usuarioService.Delete(id);
            return NoContent();
        }


    }
}
