using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregandoValoresPorDefectoaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_rol",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "usuarios",
                type: "bit",
                nullable: false,
                defaultValue: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "id_rol",
                table: "usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);
        }
    }
}
