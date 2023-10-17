using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class AddCadastroCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCadDeCompras",
                columns: table => new
                {
                    CadastroDeComprasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumNotaCompra = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCadDeCompras", x => x.CadastroDeComprasId);
                    table.ForeignKey(
                        name: "FK_tbCadDeCompras_tbFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tbFornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCadDeCompras_FornecedorId",
                table: "tbCadDeCompras",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCadDeCompras");
        }
    }
}
