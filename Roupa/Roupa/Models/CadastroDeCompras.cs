using System.ComponentModel;

namespace Roupa.Models
{
    public class CadastroDeCompras
    {
        public Guid CadastroDeComprasId { get; set; }
        [DisplayName("N° Nota da Compra")]
        public int NotaCompra { get; set; }
        [DisplayName("Data e Hora")]
        public DateTime DataHora { get; set; }

        //*************************************
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }

        //*************************************

        public IEnumerable<Compra>? Compras { get; set; }
    }
}
