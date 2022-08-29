using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LixiBanff.Migrations
{
    public partial class BaseConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ContactoCliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DetalleCliente",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Usuario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CorreoUsuario",
                table: "Usuario",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DescripcionUsuario",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoUsuario",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionCliente",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    PerfilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePerfil = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Pila",
                columns: table => new
                {
                    PilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicionPila = table.Column<int>(nullable: false),
                    CodigoPila = table.Column<string>(nullable: true),
                    NombrePila = table.Column<string>(nullable: true),
                    CantidadPanos = table.Column<int>(nullable: false),
                    AnchoPila = table.Column<double>(nullable: false),
                    LargoPila = table.Column<double>(nullable: false),
                    DescripcionPila = table.Column<string>(nullable: true),
                    UbicacionPila = table.Column<string>(nullable: true),
                    LatLongPila = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pila", x => x.PilaId);
                    table.ForeignKey(
                        name: "FK_Pila_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoNodo",
                columns: table => new
                {
                    TipoNodoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoNodo = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNodo", x => x.TipoNodoId);
                });

            migrationBuilder.CreateTable(
                name: "Pano",
                columns: table => new
                {
                    PanoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicionPano = table.Column<int>(nullable: false),
                    CodigoPano = table.Column<string>(nullable: true),
                    NombrePano = table.Column<string>(nullable: true),
                    AnchoPano = table.Column<double>(nullable: false),
                    LargoPano = table.Column<double>(nullable: false),
                    DescripcionPano = table.Column<string>(nullable: true),
                    PilaId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pano", x => x.PanoId);
                    table.ForeignKey(
                        name: "FK_Pano_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pano_Pila_PilaId",
                        column: x => x.PilaId,
                        principalTable: "Pila",
                        principalColumn: "PilaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nodo",
                columns: table => new
                {
                    NodoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicionNodo = table.Column<int>(nullable: false),
                    CodigoNodo = table.Column<string>(nullable: true),
                    NombreNodo = table.Column<string>(nullable: true),
                    Mac = table.Column<string>(nullable: true),
                    PanoId = table.Column<int>(nullable: true),
                    TipoNodoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodo", x => x.NodoId);
                    table.ForeignKey(
                        name: "FK_Nodo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodo_Pano_PanoId",
                        column: x => x.PanoId,
                        principalTable: "Pano",
                        principalColumn: "PanoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodo_TipoNodo_TipoNodoId",
                        column: x => x.TipoNodoId,
                        principalTable: "TipoNodo",
                        principalColumn: "TipoNodoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClienteId",
                table: "Usuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodo_ClienteId",
                table: "Nodo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodo_PanoId",
                table: "Nodo",
                column: "PanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodo_TipoNodoId",
                table: "Nodo",
                column: "TipoNodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pano_ClienteId",
                table: "Pano",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pano_PilaId",
                table: "Pano",
                column: "PilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pila_ClienteId",
                table: "Pila",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cliente_ClienteId",
                table: "Usuario",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "PerfilId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cliente_ClienteId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Nodo");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Pano");

            migrationBuilder.DropTable(
                name: "TipoNodo");

            migrationBuilder.DropTable(
                name: "Pila");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ClienteId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CorreoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DescripcionUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TelefonoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DescripcionCliente",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuario",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ContactoCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetalleCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");
        }
    }
}
