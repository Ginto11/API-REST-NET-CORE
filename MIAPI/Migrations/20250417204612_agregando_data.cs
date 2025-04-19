using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MIAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregando_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "productos");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                table: "usuarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<int>(
                name: "id_rol",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productos",
                table: "productos",
                column: "id_producto");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id_rol);
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "id_categoria", "descripcion", "nombre" },
                values: new object[,]
                {
                    { 1, "Dispositivos electrónicos como celulares, televisores y computadoras.", "Electrónica" },
                    { 2, "Productos para el hogar como muebles, electrodomésticos y decoración.", "Hogar" },
                    { 3, "Prendas de vestir y calzado para todas las edades y géneros.", "Ropa y Calzado" },
                    { 4, "Productos comestibles y bebidas de todo tipo.", "Alimentos y Bebidas" },
                    { 5, "Artículos deportivos y de ejercicio físico.", "Deportes" },
                    { 6, "Cosméticos, productos para el cabello, piel y más.", "Belleza y Cuidado Personal" },
                    { 7, "Juguetes para niños de todas las edades.", "Juguetes" },
                    { 8, "Accesorios y productos para vehículos.", "Automotriz" },
                    { 9, "Útiles escolares, material de oficina y organización.", "Papelería y Oficina" },
                    { 10, "Alimentos, juguetes y accesorios para mascotas.", "Mascotas" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id_rol", "nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Usuario" },
                    { 3, "Vendedor" },
                    { 4, "Cliente" },
                    { 5, "Invitado" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "id_producto", "id_categoria", "descripcion", "nombre" },
                values: new object[,]
                {
                    { 1, 1, "Portátil con procesador Intel Core i5 y 16GB RAM", "Laptop HP Pavilion 15" },
                    { 2, 3, "Pan saludable elaborado con granos enteros", "Pan integral" },
                    { 3, 5, "Raqueta profesional para jugadores intermedios", "Raqueta de tenis Wilson" },
                    { 4, 2, "Pantalones de mezclilla con corte ajustado", "Pantalones jeans para mujer" },
                    { 5, 4, "Mesa para 6 personas de madera sólida", "Mesa de comedor de madera" },
                    { 6, 1, "Teléfono inteligente de gama media con pantalla AMOLED", "Smartphone Samsung Galaxy A54" },
                    { 7, 5, "Balón oficial de entrenamiento tamaño 5", "Pelota de fútbol Adidas" },
                    { 8, 4, "Silla con soporte lumbar y ajustable en altura", "Silla ergonómica de oficina" },
                    { 9, 2, "Camisa de algodón manga larga", "Camisa casual para hombre" },
                    { 10, 3, "Fruta fresca de alta calidad", "Manzanas rojas" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id_usuario", "clave", "correo", "nombre", "id_rol" },
                values: new object[] { 1, "@Nelson11", "nelson@gmail.com", "Nelson", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_rol",
                table: "usuarios",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_categoria",
                table: "productos",
                column: "id_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_id_categoria",
                table: "productos",
                column: "id_categoria",
                principalTable: "categorias",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_id_rol",
                table: "usuarios",
                column: "id_rol",
                principalTable: "roles",
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_id_categoria",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_id_rol",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_id_rol",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productos",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_id_categoria",
                table: "productos");

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "id_usuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id_categoria",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "id_rol",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "productos",
                newName: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
