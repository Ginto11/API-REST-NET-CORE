using MIAPI.Data;
using MIAPI.Interfaces;
using MIAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MIAPI.Services
{
    public class CategoriaService : ICRUD <Categoria>
    {
        private readonly DataContext _context;
        public CategoriaService(DataContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categoria.Include(c => c.Productos).ToListAsync();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _context.Categoria.Include(c => c.Productos).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task Update(Categoria categoria)
        {
            var categoriaExistente = await GetById(categoria.Id);

            if(categoriaExistente != null) 
            {
                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Descripcion = categoria.Descripcion;

                _context.Categoria.Update(categoriaExistente);
                await _context.SaveChangesAsync();

            }
        }

        public async Task Delete(int id)
        {
            var categoriaPorEliminar = await GetById(id);

            if(categoriaPorEliminar != null)
            {
                _context.Categoria.Remove(categoriaPorEliminar);
                await _context.SaveChangesAsync();
            }
        }






    }
}
