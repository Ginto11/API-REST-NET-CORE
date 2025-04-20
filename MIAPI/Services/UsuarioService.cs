using MIAPI.Authentication;
using MIAPI.Data;
using MIAPI.Dtos;
using MIAPI.Interfaces;
using MIAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIAPI.Services
{
    public class UsuarioService : ICRUD <Usuario>
    {
        /*INYECTA DataContext EL CUAL PERMITE TRABAJAR CON LA BD*/
        private readonly DataContext context;
        public UsuarioService(DataContext context)
        {
            this.context = context;
        }

        /*LISTA DE USUARIOS*/
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await context.Usuario.Include(u => u.Rol).ToListAsync();
        }

        /*CREA UN USUARIO*/
        public async Task<Usuario> Create(Usuario usuario)
        {

            context.Usuario.Add(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        /*BUSCA UN USUARIO POR ID*/
        public async Task<Usuario?> GetById(int id)
        {
            return await context.Usuario.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Id == id);
        }

        /*ACTUALIZA UN USUARIO*/
        public async Task Update(Usuario usuario)
        {
            var usuarioPorActualizar = await GetById(usuario.Id);

            if(usuarioPorActualizar != null)
            {
                context.Usuario.Update(usuario);
                await context.SaveChangesAsync();
            }
        }

        /*ELIMINA UN USUARIO*/
        public async Task Delete(int id)
        {
            var usuarioPorEliminar = await GetById(id);

            if(usuarioPorEliminar != null)
            {
                context.Usuario.Remove(usuarioPorEliminar);
                await context.SaveChangesAsync();
            }
        }

        /*BUSCA POR EMAIL Y CONTRASEÑA*/
        public async Task<Usuario?> FindByEmailAndPass(string correo, string clave)
        {
            var usuarioEncontrado = await context.Usuario
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);

            if(usuarioEncontrado != null)
            {
                return await GetById(usuarioEncontrado.Id);
            }
            return null;

        }

        /*BUSCA POR EMAIL*/
        public async Task<Usuario?> ValidateEmail(string correo)
        {
            return await context.Usuario.FirstOrDefaultAsync(u => u.Correo == correo);
        }

    }
}
