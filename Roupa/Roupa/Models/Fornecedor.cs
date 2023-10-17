using System.ComponentModel;

namespace Roupa.Models
{
    public class Fornecedor
    {
        public Guid FornecedorId { get; set; }
        [DisplayName("Nome do Fornecedor")]
        public string Nome { get; set; }
        [DisplayName("CNPJ")]
        public int Cnpj { get; set; }

        //*************************************
        public IEnumerable<Produto>? Produtos { get; set; }

        //*************************************

        public IEnumerable<CadastroDeCompras>? CadastroDeCompras { get; set; }
    }
}
