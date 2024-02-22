using FluentValidation;
using WebAPI_Fluent_Validation.Models;

namespace WebAPI_Fluent_Validation.Validators;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(usuario => usuario.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .Length(2, 150).WithMessage("O nome deve conter de 2 a 150 caracteres.");

        RuleFor(usuario => usuario.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("O email não é válido.");

        RuleFor(usuario => usuario.Idade)
            .InclusiveBetween(18, 99).WithMessage("A idade deve estar entre 18 e 99 anos.");
    }
}
