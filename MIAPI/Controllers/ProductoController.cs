using MIAPI.Data;
using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace MIAPI.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly ProductoService service;

        public ProductoController(ProductoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> ListaProductos()
        {
            return await service.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Producto>> BuscarProducto(int id)
        {
            var producto = await service.GetById(id);

            if(producto == null)
                return BadRequest($"Producto Nº {id}, no encontrado.");

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> AgregarProducto(Producto produto)
        {
            var nuevoProducto = await service.Create(produto);
            return nuevoProducto;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest($"Error: El ID({id}) de la URL, no coincide con el ID({producto.Id}) del producto."); 

            await service.Update(producto);
            return Ok();
            
        }
         
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoPorEliminar = await service.GetById(id);

            if (productoPorEliminar == null)
                return BadRequest($"El producto Nº {id}, no existe.");

            await service.Delete(id);
            return Ok();
        }

    }
}
