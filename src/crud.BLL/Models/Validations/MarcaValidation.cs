using FluentValidation;

namespace crud.BLL.Models.Validations
{
    public class MarcaValidation : AbstractValidator<Marca>
    {
        public MarcaValidation()
        {
            RuleFor(m => m.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado !")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
