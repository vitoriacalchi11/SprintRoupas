using System.ComponentModel;

namespace Roupa.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        [DisplayName("Nome da Categoria")]
        public string Nome { get; set; }

        //**********************************
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
