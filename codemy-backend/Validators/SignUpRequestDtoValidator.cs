using codemy_backend.Models.Dtos.Request;
using FluentValidation;

namespace codemy_backend.Validators;

public class SignUpRequestDtoValidator : AbstractValidator<SignUpRequestDto>
{
    public SignUpRequestDtoValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Nome é obrigatório!")
            .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres!");
        
        RuleFor(s => s.Email)
            .NotEmpty().WithMessage("Email é obrigatório!")
            .EmailAddress().WithMessage("Email inválido!");

        RuleFor(s => s.Password)
            .NotEmpty().WithMessage("Senha é obrigatória!");

        RuleFor(s => s.Role)
            .NotEmpty().WithMessage("Role é obrigatorio");
    }
}