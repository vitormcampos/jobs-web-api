using FluentValidation;
using Jobs.Api.Users.Dtos;

namespace Jobs.Api.Users.Validators;

public class UserChangePasswordValidator : AbstractValidator<UserChangePassword>
{
    public UserChangePasswordValidator()
    {
        
    }
}