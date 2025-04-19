using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MIAPI.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService service;
        public UsuarioController(UsuarioService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await service.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuario(int id)
        {
            try { 
            
                var usuarioBuscado = await service.GetById(id);

                if (usuarioBuscado == null)
                    return StatusCode(404, new { StatusCode = 404, mensaje = $"El usuario Nº {id}, no existe." });

                return usuarioBuscado;

            } catch (Exception e) {
                return StatusCode(500, $"Error: {e.Message}");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> AgregarUsuario(Usuario usuario)
        {
            var usuarioNuevo = await service.Create(usuario);
            return usuarioNuevo;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> ActualizarUsuario(Usuario usuario, int id)
        {
            if(usuario.Id != id)
                return BadRequest($"Error: El ID({id}) de la URL, no coincide con el ID({usuario.Id}) del usuario.");
            
            var usuarioPorActualizar = await service.GetById(usuario.Id);

            if (usuarioPorActualizar == null)
                return StatusCode(404, $"El usuario Nº {usuario.Id}, no existe.");

            await service.Update(usuarioPorActualizar);
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var usuarioPorEliminar = await service.GetById(id);

            if(usuarioPorEliminar == null)
                return StatusCode(404, $"El usuario Nº {id}, no existe.");

            await service.Delete(id);
            return NoContent();
        }


    }
}
