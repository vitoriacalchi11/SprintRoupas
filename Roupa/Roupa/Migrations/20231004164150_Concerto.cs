using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roupa.Migrations
{
    /// <inheritdoc />
    public partial class Concerto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_tbClientes_CategoriaId",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbClientes",
                table: "tbClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "tbClientes",
                newName: "tbCategorias");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "tbProdutos");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "tbFornecedores");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_FornecedorId",
                table: "tbProdutos",
                newName: "IX_tbProdutos_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_CategoriaId",
                table: "tbProdutos",
                newName: "IX_tbProdutos_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbCategorias",
                table: "tbCategorias",
                column: "CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbProdutos",
                table: "tbProdutos",
                column: "ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbFornecedores",
                table: "tbFornecedores",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProdutos_tbCategorias_CategoriaId",
                table: "tbProdutos",
                column: "CategoriaId",
                principalTable: "tbCategorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbProdutos_tbFornecedores_FornecedorId",
                table: "tbProdutos",
                column: "FornecedorId",
                principalTable: "tbFornecedores",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProdutos_tbCategorias_CategoriaId",
                table: "tbProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbProdutos_tbFornecedores_FornecedorId",
                table: "tbProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbProdutos",
                table: "tbProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbFornecedores",
                table: "tbFornecedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbCategorias",
                table: "tbCategorias");

            migrationBuilder.RenameTable(
                name: "tbProdutos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "tbFornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "tbCategorias",
                newName: "tbClientes");

            migrationBuilder.RenameIndex(
                name: "IX_tbProdutos_FornecedorId",
                table: "Produto",
                newName: "IX_Produto_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_tbProdutos_CategoriaId",
                table: "Produto",
                newName: "IX_Produto_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbClientes",
                table: "tbClientes",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_tbClientes_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "tbClientes",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
