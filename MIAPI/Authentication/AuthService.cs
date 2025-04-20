using MIAPI.Dtos;
using MIAPI.Models;
using MIAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MIAPI.Authentication
{
    public class AuthService
    {
        /*INYECTA IHttpContextAccessor EL CUAL SIRVE PARA EXTRAER LOS CLAIMS*/
        private readonly IHttpContextAccessor httpContextAccessor;

        /*INYECTA IConfiguration PARA ACCEDER A LAS VARIABLES DE LA CONFIGURACION*/
        private readonly IConfiguration config;

        /*INYECTA EL SERVICIO UsuarioService EL CUAL PERMITE LA CONEXION CON LA BD*/
        private readonly UsuarioService service;
        public AuthService(UsuarioService service, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this.service = service;
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }

        /*VERIFICA QUE EL CORREO DEL USUARIO EXISTA EN LA BD Y VERIFICA QUE LA CONTRASEÑA SEA LA MISMA*/
        public async Task<Usuario?> Authenticate(UsuarioLoginDto usuario)
        {
            var usuarioEncontrado = await service.ValidateEmail(usuario.Correo);

            if (usuarioEncontrado != null)
            {
                if(usuarioEncontrado.Clave == Encriptar(usuario.Clave))
                {
                    return await service.FindByEmailAndPass(usuarioEncontrado.Correo, usuarioEncontrado.Clave);
                }
            }

            return null;
        }

        /*GENERA EL TOKEN CUANDO SE HA VERIFICADO LA AUTENTICACION*/
        public string GenerarTokenJWT(Usuario usuario)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //CREAR LOS CLAIMS
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre)
            };
            //CREAR EL TOKEN
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*EXTRAE EL USUARIO DEL TOKEN REGISTRADO*/
        public UsuarioLogeadoDto? GetUsuarioFromToken()
        {
            var identity = httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            Console.Write(identity);
            if(identity != null)
            {
                var usuarioClaims = identity.Claims;

                return new UsuarioLogeadoDto
                {
                    Nombre = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value,
                    Correo = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value,
                    Rol = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }

        /*ENCRIPTA LA CONTRASEÑA DEL USUARIO*/
        public string Encriptar(string textoPlano)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(config["Encryting:Key"]!);
            aes.IV = Encoding.UTF8.GetBytes(config["Encryting:IV"]!);

            ICryptoTransform encryptor = aes.CreateEncryptor();

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncryp = new StreamWriter(csEncrypt))
            {
                swEncryp.Write(textoPlano);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        /*DESENCRIPTA LA CONTRASEÑA DEL USUARIO*/
        public string Desencriptar(string textoEncriptado)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(config["Encryting:Key"]!);
            aes.IV = Encoding.UTF8.GetBytes(config["Encryting:IV"]!);

            ICryptoTransform decryptor = aes.CreateDecryptor();

            byte[] textCifrado = Convert.FromBase64String(textoEncriptado);
            using MemoryStream msEncrypt = new(textCifrado);
            using CryptoStream csEncrypt = new(msEncrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srcDecrypt = new(csEncrypt);

            return srcDecrypt.ReadToEnd();
        }
    }
}
