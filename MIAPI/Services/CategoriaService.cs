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

        /*INYECTA DataContext EL CUAL PERMITE TRABAJAR CON LA BD*/
        private readonly DataContext context;
        public CategoriaService(DataContext context) {
            this.context = context;
        }

        /*LISTA DE CATEGORIAS*/
        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await context.Categoria.Include(c => c.Productos).ToListAsync();
        }

        /*BUSCAR CATEGORIA POR ID*/
        public async Task<Categoria?> GetById(int id)
        {
            return await context.Categoria.Include(c => c.Productos).FirstOrDefaultAsync(c => c.Id == id);
        }

        /*CREAR UNA CATEGORIA*/
        public async Task<Categoria> Create(Categoria categoria)
        {
            context.Categoria.Add(categoria);
            await context.SaveChangesAsync();
            return categoria;
        }

        /*ACTUALIZA UNA CATEGORIA*/
        public async Task Update(Categoria categoria)
        {
            var categoriaExistente = await GetById(categoria.Id);

            if(categoriaExistente != null) 
            {
                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Descripcion = categoria.Descripcion;

                context.Categoria.Update(categoriaExistente);
                await context.SaveChangesAsync();

            }
        }

        /*ELIMINA UNA CATEGORIA*/
        public async Task Delete(int id)
        {
            var categoriaPorEliminar = await GetById(id);

            if(categoriaPorEliminar != null)
            {
                context.Categoria.Remove(categoriaPorEliminar);
                await context.SaveChangesAsync();
            }
        }






    }
}
