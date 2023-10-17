using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class Arrumar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotaCompra",
                table: "tbCadDeVendas",
                newName: "NotaVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotaVenda",
                table: "tbCadDeVendas",
                newName: "NotaCompra");
        }
    }
}
