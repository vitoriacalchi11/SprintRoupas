using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CadastroDeComprasId",
                table: "tbCompras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "tbCompras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbCompras_CadastroDeComprasId",
                table: "tbCompras",
                column: "CadastroDeComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCompras_ProdutoId",
                table: "tbCompras",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCompras_tbCadDeCompras_CadastroDeComprasId",
                table: "tbCompras",
                column: "CadastroDeComprasId",
                principalTable: "tbCadDeCompras",
                principalColumn: "CadastroDeComprasId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCompras_tbProdutos_ProdutoId",
                table: "tbCompras",
                column: "ProdutoId",
                principalTable: "tbProdutos",
                principalColumn: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCompras_tbCadDeCompras_CadastroDeComprasId",
                table: "tbCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_tbCompras_tbProdutos_ProdutoId",
                table: "tbCompras");

            migrationBuilder.DropIndex(
                name: "IX_tbCompras_CadastroDeComprasId",
                table: "tbCompras");

            migrationBuilder.DropIndex(
                name: "IX_tbCompras_ProdutoId",
                table: "tbCompras");

            migrationBuilder.DropColumn(
                name: "CadastroDeComprasId",
                table: "tbCompras");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "tbCompras");
        }
    }
}
