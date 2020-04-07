using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Saldo = table.Column<double>(nullable: false),
                    Periodo = table.Column<int>(nullable: false),
                    TipoDeposito = table.Column<string>(nullable: true),
                    TasaInteres = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuentaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Saldo = table.Column<double>(nullable: false),
                    Ciudad = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Deuda = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaBancaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoFinanciero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaBancariaId = table.Column<int>(nullable: true),
                    ValorRetiro = table.Column<double>(nullable: false),
                    ValorConsignacion = table.Column<double>(nullable: false),
                    FechaMovimiento = table.Column<DateTime>(nullable: false),
                    CDTId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoFinanciero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoFinanciero_CDT_CDTId",
                        column: x => x.CDTId,
                        principalTable: "CDT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoFinanciero_CuentaBancaria_CuentaBancariaId",
                        column: x => x.CuentaBancariaId,
                        principalTable: "CuentaBancaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoFinanciero_CDTId",
                table: "MovimientoFinanciero",
                column: "CDTId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoFinanciero_CuentaBancariaId",
                table: "MovimientoFinanciero",
                column: "CuentaBancariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientoFinanciero");

            migrationBuilder.DropTable(
                name: "CDT");

            migrationBuilder.DropTable(
                name: "CuentaBancaria");
        }
    }
}
