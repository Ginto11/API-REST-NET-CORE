using MIAPI.Data;
using MIAPI.Interfaces;
using MIAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MIAPI.Services
{
    public class ProductoService : ICRUD <Producto>
    {
        private readonly DataContext _context;

        public ProductoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.Producto.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await _context.Producto.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producto> Create(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task Update(Producto producto)
        {
            var productoExistente = await GetById(producto.Id);

            if(productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.CategoriaId = producto.CategoriaId;

                _context.Producto.Update(productoExistente);
                await _context.SaveChangesAsync();

            }
        }


        public async Task Delete(int id)
        {
            var productoAEliminar = await GetById(id);

            if(productoAEliminar != null)
            {
                _context.Producto.Remove(productoAEliminar);
                await _context.SaveChangesAsync();
            }
        }

    }
}
