using System.ComponentModel;

namespace Roupa.Models
{
    public class Venda
    {
        public Guid VendaId { get; set; }
        [DisplayName("Nome Venda")]
        public Guid? CadastroDeVendasId { get; set; }
        [DisplayName("Cadastro de Vendas")]
        public CadastroDeVendas? CadastroDeVendas { get; set; }

        public int Quantidade { get; set; }

        //**********************************
        [DisplayName("Produto")]
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        //************************************
        [DisplayName("Preço Unitário")]
        public decimal PrecoUnitario { get; set; }

    }
}
