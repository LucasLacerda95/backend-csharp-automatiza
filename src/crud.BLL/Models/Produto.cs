

namespace crud.BLL.Models
{
    public class Produto : Entity
    {
        public Guid ProdutoID { get; set; }

        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Status { get; set; }


        //Relacionamento Entity
        public Marca MarcaId { get; set; }

    }
}
