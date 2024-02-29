using System.ComponentModel.DataAnnotations;

namespace crud.API.ViewModels
{
    public class MarcaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Descricao { get; set; }
        

        public string Situacao { get; set; }
    }
}
