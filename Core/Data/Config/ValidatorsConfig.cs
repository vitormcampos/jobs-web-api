using FluentValidation;
using Jobs.Api.Auth.Dtos;
using Jobs.Api.Auth.Validators;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.Validators;
using Jobs.Api.Users.Dtos;
using Jobs.Api.Users.Validators;

namespace Jobs.Core.Data.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<JobRequestDto>, JobRequestValidator>();
        services.AddScoped<IValidator<UserRequestDto>, UserRequestValidator>();
        services.AddScoped<IValidator<LoginRequestDto>, LoginRequestValidator>();
    }
}