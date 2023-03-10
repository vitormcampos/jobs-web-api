using FluentValidation;
using Jobs.Api.Auth.Dtos;

namespace Jobs.Api.Auth.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(l => l.Login)
            .NotEmpty().WithMessage("{ProperyName} é requerido");
        
        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("{ProperyName} é requerido");
    }
}