using MIAPI.Data;
using MIAPI.Models;
using MIAPI.Services;

namespace MIAPI.Authentication
{
    public class AuthService
    {
        private readonly UsuarioService service;
        public AuthService(UsuarioService service)
        {
            this.service = service;
        }


        public Task Registrar(Usuario usuario)
        {
            return Task.FromResult(0);
        }

        public Task Login(Usuario usuario)
        {
            return Task.FromResult(0);
        }

    }
}
