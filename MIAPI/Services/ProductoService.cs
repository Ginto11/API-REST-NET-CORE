using MIAPI.Data;
using MIAPI.Interfaces;
using MIAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MIAPI.Services
{
    public class ProductoService : ICRUD <Producto>
    {
        /*INYECTA DataContext EL CUAL PERMITE TRABAJAR CON LA BD*/
        private readonly DataContext context;

        public ProductoService(DataContext context)
        {
            this.context = context;
        }

        /*LISTA DE PRODUCTOS*/
        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await context.Producto.Include(p => p.Categoria).ToListAsync();
        }

        /*BUSCAR PRODUCTO POR ID*/
        public async Task<Producto?> GetById(int id)
        {
            return await context.Producto.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        /*CREA UN PRODUCTO*/
        public async Task<Producto> Create(Producto producto)
        {
            context.Producto.Add(producto);
            await context.SaveChangesAsync();

            return producto;
        }

        /*ACTUALIZA UN PRODCUTO*/
        public async Task Update(Producto producto)
        {
            var productoExistente = await GetById(producto.Id);

            if(productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.CategoriaId = producto.CategoriaId;

                context.Producto.Update(productoExistente);
                await context.SaveChangesAsync();

            }
        }

        /*ELIMINA UN PRODUCTO*/
        public async Task Delete(int id)
        {
            var productoAEliminar = await GetById(id);

            if(productoAEliminar != null)
            {
                context.Producto.Remove(productoAEliminar);
                await context.SaveChangesAsync();
            }
        }

    }
}
