using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "tbCadDeVendas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbCadDeVendas_ClienteId",
                table: "tbCadDeVendas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCadDeVendas_tbClientes_ClienteId",
                table: "tbCadDeVendas",
                column: "ClienteId",
                principalTable: "tbClientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCadDeVendas_tbClientes_ClienteId",
                table: "tbCadDeVendas");

            migrationBuilder.DropIndex(
                name: "IX_tbCadDeVendas_ClienteId",
                table: "tbCadDeVendas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "tbCadDeVendas");
        }
    }
}
