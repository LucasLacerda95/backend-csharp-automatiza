
namespace crud.BLL.Models
{
    public class Produto : Entity
    {

        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Situacao { get; set; }
        public Guid id_Marca { get; set; }

    }
}
