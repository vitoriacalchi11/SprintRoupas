using System.ComponentModel;

namespace Roupa.Models
{
    public class Compra
    {
        public Guid CompraId { get; set; }
        [DisplayName("Nome Compra")]
        public Guid? CadastroDeComprasId { get; set; }
        [DisplayName("Cadastro de Compras")]
        public CadastroDeCompras? CadastroDeCompras { get; set; }
        public int Quantidade { get; set; }
        [DisplayName("Produto")]
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        [DisplayName("Preço Unitário")]
        public decimal PrecoUnitario { get; set; }

    }
}
