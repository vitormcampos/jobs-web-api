using FluentValidation;
using Jobs.Api.Users.Dtos;

namespace Jobs.Api.Users.Validators;

public class UserRequestValidator : AbstractValidator<UserRequestDto>
{
    public UserRequestValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Campo de {PropertyName} requerido")
            .EmailAddress().WithMessage("Digite um e-mail válido");

        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("Campo de {PropertyName} requerido");
        
        RuleFor(u => u.Telefone)
            .NotEmpty().WithMessage("Campo de {PropertyName} requerido");
        
        RuleFor(u => u.Senha)
            .NotEmpty().WithMessage("Campo de {PropertyName} requerido");
    }
}