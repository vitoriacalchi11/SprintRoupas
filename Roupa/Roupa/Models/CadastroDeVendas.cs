using System.ComponentModel;

namespace Roupa.Models
{
    public class CadastroDeVendas
    {
        public Guid CadastroDeVendasId { get; set; }
        [DisplayName("N° Nota da Venda")]
        public int NotaVenda { get; set; }
        [DisplayName("Data e Hora")]
        public DateTime DataHora { get; set; }

        //*************************************
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        //*************************************

        public IEnumerable<Venda>? Vendas { get; set; }
    }
}
