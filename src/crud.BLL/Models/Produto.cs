using System.ComponentModel.DataAnnotations.Schema;

namespace crud.BLL.Models
{
    public class Produto : Entity
    {

        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Status { get; set; }
        public Guid codigo_Marca { get; set; }


    }
}
