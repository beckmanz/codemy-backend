using codemy_backend.Models.Dtos.Request;
using FluentValidation;

namespace codemy_backend.Validators;

public class SignInRequestDtoValidator: AbstractValidator<SignInRequestDto>
{
    public SignInRequestDtoValidator()
    {
        RuleFor(s => s.Email)
            .NotEmpty().WithMessage("Email é obrigatório!")
            .EmailAddress().WithMessage("Email inválido!");

        RuleFor(s => s.Password)
            .NotEmpty().WithMessage("Senha é obrigatória!");
    }
}