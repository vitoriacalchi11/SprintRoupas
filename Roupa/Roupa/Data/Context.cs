using Microsoft.EntityFrameworkCore;
using Roupa.Models;

namespace Roupa.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("tbCategorias");
            modelBuilder.Entity<Fornecedor>().ToTable("tbFornecedores");
            modelBuilder.Entity<Produto>().ToTable("tbProdutos");
            modelBuilder.Entity<CadastroDeCompras>().ToTable("tbCadDeCompras");
            modelBuilder.Entity<Cliente>().ToTable("tbClientes");
            modelBuilder.Entity<CadastroDeVendas>().ToTable("tbCadDeVendas");
            modelBuilder.Entity<Venda>().ToTable("tbVendas");
            modelBuilder.Entity<Compra>().ToTable("tbCompras");
        }

        public DbSet<Roupa.Models.Produto> Produto { get; set; } = default!;

        public DbSet<Roupa.Models.Fornecedor> Fornecedor { get; set; } = default!;

        public DbSet<Roupa.Models.CadastroDeCompras> CadastroDeCompras { get; set; } = default!;

        public DbSet<Roupa.Models.CadastroDeVendas> CadastroDeVendas { get; set; } = default!;

        public DbSet<Roupa.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Roupa.Models.Venda> Venda { get; set; } = default!;

        public DbSet<Roupa.Models.Compra> Compra { get; set; } = default!;

    }
}
