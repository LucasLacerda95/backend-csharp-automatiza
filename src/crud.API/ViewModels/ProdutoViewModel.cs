using System.ComponentModel.DataAnnotations;

namespace crud.API.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public string Situacao { get; set; }

        public Guid codigo_Marca { get; set; }

    }
}
