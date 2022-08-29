using Microsoft.EntityFrameworkCore.Migrations;

namespace LixiBanff.Migrations
{
    public partial class AddOrdenPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdenPerfil",
                table: "Perfil",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdenPerfil",
                table: "Perfil");
        }
    }
}
