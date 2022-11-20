using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LixiBanff.Migrations
{
    public partial class addSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicionSensor = table.Column<int>(nullable: false),
                    CodigoSensor = table.Column<string>(nullable: true),
                    NombreSensor = table.Column<string>(nullable: true),
                    Mac = table.Column<string>(nullable: true),
                    NodoId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_Sensor_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sensor_Nodo_NodoId",
                        column: x => x.NodoId,
                        principalTable: "Nodo",
                        principalColumn: "NodoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_ClienteId",
                table: "Sensor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_NodoId",
                table: "Sensor",
                column: "NodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
