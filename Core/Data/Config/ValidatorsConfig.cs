using FluentValidation;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.Validators;

namespace Jobs.Core.Data.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<JobRequestDto>, JobRequestValidator>();
    }
}