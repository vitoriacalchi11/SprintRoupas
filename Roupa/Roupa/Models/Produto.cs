using System.ComponentModel;

namespace Roupa.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }
        public int Estoque { get; set; }
        [DisplayName("Preço Unitário")]
        public decimal PrecoUnitario { get; set; }

        //*****************************************************
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        //*******************************************************
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set;}

    }
}
