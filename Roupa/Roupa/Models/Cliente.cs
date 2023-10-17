using System.ComponentModel;

namespace Roupa.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public int CPF { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        public IEnumerable<CadastroDeVendas>? CadastroDeVendas { get; set; }
    }
}
