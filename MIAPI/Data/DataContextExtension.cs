using MIAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MIAPI.Data
{
    public static class DataContextExtension
    {
        public static void Seed (this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Electrónica", Descripcion = "Dispositivos electrónicos como celulares, televisores y computadoras." },
                new Categoria { Id = 2, Nombre = "Hogar", Descripcion = "Productos para el hogar como muebles, electrodomésticos y decoración." },
                new Categoria { Id = 3, Nombre = "Ropa y Calzado", Descripcion = "Prendas de vestir y calzado para todas las edades y géneros." },
                new Categoria { Id = 4, Nombre = "Alimentos y Bebidas", Descripcion = "Productos comestibles y bebidas de todo tipo." },
                new Categoria { Id = 5, Nombre = "Deportes", Descripcion = "Artículos deportivos y de ejercicio físico." },
                new Categoria { Id = 6, Nombre = "Belleza y Cuidado Personal", Descripcion = "Cosméticos, productos para el cabello, piel y más." },
                new Categoria { Id = 7, Nombre = "Juguetes", Descripcion = "Juguetes para niños de todas las edades." },
                new Categoria { Id = 8, Nombre = "Automotriz", Descripcion = "Accesorios y productos para vehículos." },
                new Categoria { Id = 9, Nombre = "Papelería y Oficina", Descripcion = "Útiles escolares, material de oficina y organización." },
                new Categoria { Id = 10, Nombre = "Mascotas", Descripcion = "Alimentos, juguetes y accesorios para mascotas." }
            );

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Administrador" },
                new Rol { Id = 2, Nombre = "Usuario" },
                new Rol { Id = 3, Nombre = "Vendedor" },
                new Rol { Id = 4, Nombre = "Cliente" },
                new Rol { Id = 5, Nombre = "Invitado" }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop HP Pavilion 15", Descripcion = "Portátil con procesador Intel Core i5 y 16GB RAM", CategoriaId = 1 },
                new Producto { Id = 2, Nombre = "Pan integral", Descripcion = "Pan saludable elaborado con granos enteros", CategoriaId = 3 },
                new Producto { Id = 3, Nombre = "Raqueta de tenis Wilson", Descripcion = "Raqueta profesional para jugadores intermedios", CategoriaId = 5 },
                new Producto { Id = 4, Nombre = "Pantalones jeans para mujer", Descripcion = "Pantalones de mezclilla con corte ajustado", CategoriaId = 2 },
                new Producto { Id = 5, Nombre = "Mesa de comedor de madera", Descripcion = "Mesa para 6 personas de madera sólida", CategoriaId = 4 },
                new Producto { Id = 6, Nombre = "Smartphone Samsung Galaxy A54", Descripcion = "Teléfono inteligente de gama media con pantalla AMOLED", CategoriaId = 1 },
                new Producto { Id = 7, Nombre = "Pelota de fútbol Adidas", Descripcion = "Balón oficial de entrenamiento tamaño 5", CategoriaId = 5 },
                new Producto { Id = 8, Nombre = "Silla ergonómica de oficina", Descripcion = "Silla con soporte lumbar y ajustable en altura", CategoriaId = 4 },
                new Producto { Id = 9, Nombre = "Camisa casual para hombre", Descripcion = "Camisa de algodón manga larga", CategoriaId = 2 },
                new Producto { Id = 10, Nombre = "Manzanas rojas", Descripcion = "Fruta fresca de alta calidad", CategoriaId = 3 }
            );

            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, Nombre = "Nelson", Correo = "nelson@gmail.com", Clave = "@Nelson11", RolId = 1});

        }
    }
}
