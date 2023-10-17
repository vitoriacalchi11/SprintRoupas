using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class AddNotaCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotaCompra",
                table: "tbCadDeCompras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaCompra",
                table: "tbCadDeCompras");
        }
    }
}
