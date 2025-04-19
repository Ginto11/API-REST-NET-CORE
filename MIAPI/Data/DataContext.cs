using MIAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MIAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Rol> Rol { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(modelo => modelo.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Seed();

        }

    }
}
