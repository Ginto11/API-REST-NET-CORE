using MIAPI.Authentication;
using MIAPI.Data;
using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        /*INYECTA EL SERVICIO ProductoService EL CUAL PERMITE LA CONEXION CON LA BASE DE DATOS*/
        private readonly ProductoService productoService;

        /*INYECTA EL SERVIIO AuthService EL CUAL PERMITE USAR CIERTAS UTILIDADES*/
        private readonly AuthService authService;

        public ProductoController(ProductoService service, AuthService authService)
        {
            this.productoService = service;
            this.authService = authService;
        }

        /*METODO QUE REGRESA UNA LISTA DE PRODUCTOS*/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Producto>> ListaProductos()
        {
            authService.GetUsuarioFromToken();
            return await productoService.GetAll();
        }

        /*METODO QUE PERMITE BUSCAR UN PRODUCTO POR ID*/
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Producto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Producto>> BuscarProducto(int id)
        {
            var producto = await productoService.GetById(id);

            if(producto == null)
                return NotFound($"Producto Nº {id}, no encontrado.");

            return Ok(producto);
        }

        /*METODO QUE PERMIRE CREAR UN NUEVO PRODUCTO*/
        [HttpPost]
        [Authorize(Roles = "Empleado")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Producto>> AgregarProducto(Producto produto)
        {
            var nuevoProducto = await productoService.Create(produto);
            return Ok(nuevoProducto);
        }

        /*METODO QUE PERMITE ACTUALIZAR UN PRODUCTO*/
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Empleado")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarProducto(int id, Producto producto)
        {
            var usuarioEncontrado = await productoService.GetById(id);

            if (usuarioEncontrado != null)
                return NotFound("Producto no encontrado");

            if (id != producto.Id)
                return BadRequest($"Error: El ID({id}) de la URL, no coincide con el ID({producto.Id}) del producto."); 

            await productoService.Update(producto);
            return NoContent();
            
        }
         
        /*METODO QUE PERMITE ELIMINAR UN PRODCUTO*/
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Empleado")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoPorEliminar = await productoService.GetById(id);

            if (productoPorEliminar == null)
                return NotFound($"El producto Nº {id}, no existe.");

            await productoService.Delete(id);
            return NoContent();
        }

    }
}
