using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteECadVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCadDeVendas",
                columns: table => new
                {
                    CadastroDeVendasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaCompra = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCadDeVendas", x => x.CadastroDeVendasId);
                });

            migrationBuilder.CreateTable(
                name: "tbClientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbClientes", x => x.ClienteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCadDeVendas");

            migrationBuilder.DropTable(
                name: "tbClientes");
        }
    }
}
