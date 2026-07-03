using FluentValidation;
using WebApplication1.Models;
using WebApplication1.Helpers;

namespace WebApplication1.Validators;

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(x => x.Nome)
        .NotEmpty().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.CPF)
        .NotEmpty().WithMessage("O CPF é obrigatório.")
        .Length(11)
        .Matches(@"^\d+$")
        .WithMessage("O CPF deve conter 11 caracteres.");

        RuleFor(x => x.CPF)
            .Must(CpfHelper.Validar)
            .WithMessage("CPF Invalido");
    }
}
