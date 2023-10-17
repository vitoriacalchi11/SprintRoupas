﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Roupa.Data;

#nullable disable

namespace Roupa.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231010174538_AddEntityCadVendas")]
    partial class AddEntityCadVendas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Roupa.Models.CadastroDeCompras", b =>
                {
                    b.Property<Guid>("CadastroDeComprasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NotaCompra")
                        .HasColumnType("int");

                    b.HasKey("CadastroDeComprasId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("tbCadDeCompras", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.CadastroDeVendas", b =>
                {
                    b.Property<Guid>("CadastroDeVendasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaVenda")
                        .HasColumnType("int");

                    b.HasKey("CadastroDeVendasId");

                    b.HasIndex("ClienteId");

                    b.ToTable("tbCadDeVendas", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("tbCategorias", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.ToTable("tbClientes", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cnpj")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FornecedorId");

                    b.ToTable("tbFornecedores", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.Produto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("tbProdutos", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.Venda", b =>
                {
                    b.Property<Guid>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CadastroDeVendasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("VendaId");

                    b.HasIndex("CadastroDeVendasId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tbVendas", (string)null);
                });

            modelBuilder.Entity("Roupa.Models.CadastroDeCompras", b =>
                {
                    b.HasOne("Roupa.Models.Fornecedor", "Fornecedor")
                        .WithMany("CadastroDeCompras")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("Roupa.Models.CadastroDeVendas", b =>
                {
                    b.HasOne("Roupa.Models.Cliente", "Cliente")
                        .WithMany("CadastroDeVendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Roupa.Models.Produto", b =>
                {
                    b.HasOne("Roupa.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Roupa.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("Roupa.Models.Venda", b =>
                {
                    b.HasOne("Roupa.Models.CadastroDeVendas", "CadastroDeVendas")
                        .WithMany("Vendas")
                        .HasForeignKey("CadastroDeVendasId");

                    b.HasOne("Roupa.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("CadastroDeVendas");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Roupa.Models.CadastroDeVendas", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("Roupa.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Roupa.Models.Cliente", b =>
                {
                    b.Navigation("CadastroDeVendas");
                });

            modelBuilder.Entity("Roupa.Models.Fornecedor", b =>
                {
                    b.Navigation("CadastroDeCompras");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
