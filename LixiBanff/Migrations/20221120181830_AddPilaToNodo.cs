using Microsoft.EntityFrameworkCore.Migrations;

namespace LixiBanff.Migrations
{
    public partial class AddPilaToNodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PilaId",
                table: "Nodo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodo_PilaId",
                table: "Nodo",
                column: "PilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodo_Pila_PilaId",
                table: "Nodo",
                column: "PilaId",
                principalTable: "Pila",
                principalColumn: "PilaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodo_Pila_PilaId",
                table: "Nodo");

            migrationBuilder.DropIndex(
                name: "IX_Nodo_PilaId",
                table: "Nodo");

            migrationBuilder.DropColumn(
                name: "PilaId",
                table: "Nodo");
        }
    }
}
