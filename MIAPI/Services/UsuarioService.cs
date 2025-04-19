using MIAPI.Data;
using MIAPI.Interfaces;
using MIAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MIAPI.Services
{
    public class UsuarioService : ICRUD <Usuario>
    {
        private readonly DataContext _context;
        public UsuarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuario.Include(u => u.Rol).ToListAsync();
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> GetById(int id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task Update(Usuario usuario)
        {
            var usuarioPorActualizar = await GetById(usuario.Id);

            if(usuarioPorActualizar != null)
            {
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var usuarioPorEliminar = await GetById(id);

            if(usuarioPorEliminar != null)
            {
                _context.Usuario.Remove(usuarioPorEliminar);
                await _context.SaveChangesAsync();
            }
        }

    }
}
