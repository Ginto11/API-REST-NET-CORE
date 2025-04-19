using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MIAPI.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService service;

        public CategoriaController(CategoriaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            return await service.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Categoria>> BuscarCategoria(int id)
        {
            var categoria = await service.GetById(id);

            if (categoria == null)
                return BadRequest($"La categoria Nº {id}, no existe.");

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> AgregarCategoria(Categoria categoria)
        {
            var nuevaCategoria = await service.Create(categoria);
            return Ok(nuevaCategoria);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            try {

                if (id != categoria.Id)
                    throw new Exception($"El ID({id}) de la URL, no coincide con el ID({categoria.Id}) de la categoria.");

                await service.Update(categoria);
                return Ok();

            } catch (Exception e) {
                return StatusCode(500, $"Error: {e.Message}");
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var categoriaPorEliminar = await service.GetById(id);

            if (categoriaPorEliminar == null)
                BadRequest($"La categoria Nº {id}, no existe.");

            await service.Delete(id);

            return Ok();

        }
    }
}
