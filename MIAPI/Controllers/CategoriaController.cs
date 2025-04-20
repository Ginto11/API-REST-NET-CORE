using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MIAPI.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        /*INYECTA EL SERVICIO CategoriaService EL CUAL PERMITE LA CONEXION CON LA BASE DE DATOS*/
        private readonly CategoriaService categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        /*METODO QUE DEVUELVE LISTA DE CATEGORIAS*/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            return await categoriaService.GetAll();
        }

        /*METODO QUE PERMITE BUSCAR LA CATEGORIA POR ID*/
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Categoria>> BuscarCategoria(int id)
        {
            var categoria = await categoriaService.GetById(id);

            if (categoria == null)
                return NotFound($"La categoria Nº {id}, no existe.");

            return Ok(categoria);
        }

        /*METODO QUE PERMITE AGREGAR UNA CATEGORIA*/
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Empleado")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Categoria>> AgregarCategoria(Categoria categoria)
        {
            var nuevaCategoria = await categoriaService.Create(categoria);
            return Ok(nuevaCategoria);
        }

        /*METODO QUE PERMITE ACTUALIZAR UNA CATEGORIA*/
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            try {

                if (id != categoria.Id)
                    throw new Exception($"El ID({id}) de la URL, no coincide con el ID({categoria.Id}) de la categoria.");

                await categoriaService.Update(categoria);
                return Ok();

            } catch (Exception e) {
                return StatusCode(500, $"Error: {e.Message}");
            }
            
        }

        /*METODO QUE PERMITE ELIMINAR CATEGORIA*/
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var categoriaPorEliminar = await categoriaService.GetById(id);

            if (categoriaPorEliminar == null)
                NotFound($"La categoria Nº {id}, no existe.");

            await categoriaService.Delete(id);

            return NoContent();

        }
    }
}
