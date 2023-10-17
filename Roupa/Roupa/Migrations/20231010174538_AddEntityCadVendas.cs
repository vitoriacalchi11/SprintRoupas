using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityCadVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CadastroDeVendasId",
                table: "tbVendas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "tbVendas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbVendas_CadastroDeVendasId",
                table: "tbVendas",
                column: "CadastroDeVendasId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVendas_ProdutoId",
                table: "tbVendas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbVendas_tbCadDeVendas_CadastroDeVendasId",
                table: "tbVendas",
                column: "CadastroDeVendasId",
                principalTable: "tbCadDeVendas",
                principalColumn: "CadastroDeVendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbVendas_tbProdutos_ProdutoId",
                table: "tbVendas",
                column: "ProdutoId",
                principalTable: "tbProdutos",
                principalColumn: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbVendas_tbCadDeVendas_CadastroDeVendasId",
                table: "tbVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_tbVendas_tbProdutos_ProdutoId",
                table: "tbVendas");

            migrationBuilder.DropIndex(
                name: "IX_tbVendas_CadastroDeVendasId",
                table: "tbVendas");

            migrationBuilder.DropIndex(
                name: "IX_tbVendas_ProdutoId",
                table: "tbVendas");

            migrationBuilder.DropColumn(
                name: "CadastroDeVendasId",
                table: "tbVendas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "tbVendas");
        }
    }
}
