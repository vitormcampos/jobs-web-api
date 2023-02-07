using FluentValidation;
using Jobs.Api.Jobs.Dtos;

namespace Jobs.Api.Jobs.Validators;

public class JobRequestValidator : AbstractValidator<JobRequestDto>
{
    public JobRequestValidator()
    {
        RuleFor(j => j.Salary)
            .GreaterThan(0)
            .OverridePropertyName("salary");
        
        RuleFor(j => j.Title)
            .NotEmpty()
            .OverridePropertyName("title");
        
        RuleFor(j => j.Requirements)
            .NotEmpty()
            .OverridePropertyName("requirements");
    }
}