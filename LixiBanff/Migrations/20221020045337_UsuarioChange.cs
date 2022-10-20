using Microsoft.EntityFrameworkCore.Migrations;

namespace LixiBanff.Migrations
{
    public partial class UsuarioChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordNotEncripted",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordNotEncripted",
                table: "Usuario");
        }
    }
}
