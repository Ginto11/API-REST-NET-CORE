﻿// <auto-generated />
using System;
using MIAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MIAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MIAPI.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Dispositivos electrónicos como celulares, televisores y computadoras.",
                            Nombre = "Electrónica"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Productos para el hogar como muebles, electrodomésticos y decoración.",
                            Nombre = "Hogar"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Prendas de vestir y calzado para todas las edades y géneros.",
                            Nombre = "Ropa y Calzado"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Productos comestibles y bebidas de todo tipo.",
                            Nombre = "Alimentos y Bebidas"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Artículos deportivos y de ejercicio físico.",
                            Nombre = "Deportes"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Cosméticos, productos para el cabello, piel y más.",
                            Nombre = "Belleza y Cuidado Personal"
                        },
                        new
                        {
                            Id = 7,
                            Descripcion = "Juguetes para niños de todas las edades.",
                            Nombre = "Juguetes"
                        },
                        new
                        {
                            Id = 8,
                            Descripcion = "Accesorios y productos para vehículos.",
                            Nombre = "Automotriz"
                        },
                        new
                        {
                            Id = 9,
                            Descripcion = "Útiles escolares, material de oficina y organización.",
                            Nombre = "Papelería y Oficina"
                        },
                        new
                        {
                            Id = 10,
                            Descripcion = "Alimentos, juguetes y accesorios para mascotas.",
                            Nombre = "Mascotas"
                        });
                });

            modelBuilder.Entity("MIAPI.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_producto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            Descripcion = "Portátil con procesador Intel Core i5 y 16GB RAM",
                            Nombre = "Laptop HP Pavilion 15"
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 3,
                            Descripcion = "Pan saludable elaborado con granos enteros",
                            Nombre = "Pan integral"
                        },
                        new
                        {
                            Id = 3,
                            CategoriaId = 5,
                            Descripcion = "Raqueta profesional para jugadores intermedios",
                            Nombre = "Raqueta de tenis Wilson"
                        },
                        new
                        {
                            Id = 4,
                            CategoriaId = 2,
                            Descripcion = "Pantalones de mezclilla con corte ajustado",
                            Nombre = "Pantalones jeans para mujer"
                        },
                        new
                        {
                            Id = 5,
                            CategoriaId = 4,
                            Descripcion = "Mesa para 6 personas de madera sólida",
                            Nombre = "Mesa de comedor de madera"
                        },
                        new
                        {
                            Id = 6,
                            CategoriaId = 1,
                            Descripcion = "Teléfono inteligente de gama media con pantalla AMOLED",
                            Nombre = "Smartphone Samsung Galaxy A54"
                        },
                        new
                        {
                            Id = 7,
                            CategoriaId = 5,
                            Descripcion = "Balón oficial de entrenamiento tamaño 5",
                            Nombre = "Pelota de fútbol Adidas"
                        },
                        new
                        {
                            Id = 8,
                            CategoriaId = 4,
                            Descripcion = "Silla con soporte lumbar y ajustable en altura",
                            Nombre = "Silla ergonómica de oficina"
                        },
                        new
                        {
                            Id = 9,
                            CategoriaId = 2,
                            Descripcion = "Camisa de algodón manga larga",
                            Nombre = "Camisa casual para hombre"
                        },
                        new
                        {
                            Id = 10,
                            CategoriaId = 3,
                            Descripcion = "Fruta fresca de alta calidad",
                            Nombre = "Manzanas rojas"
                        });
                });

            modelBuilder.Entity("MIAPI.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_rol");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Usuario"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Vendedor"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Cliente"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Invitado"
                        });
                });

            modelBuilder.Entity("MIAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("clave");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("correo");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_creacion")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("isActive");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2)
                        .HasColumnName("id_rol");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Clave = "@Nelson11",
                            Correo = "nelson@gmail.com",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Nombre = "Nelson",
                            RolId = 1
                        });
                });

            modelBuilder.Entity("MIAPI.Models.Producto", b =>
                {
                    b.HasOne("MIAPI.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("MIAPI.Models.Usuario", b =>
                {
                    b.HasOne("MIAPI.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("MIAPI.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("MIAPI.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
