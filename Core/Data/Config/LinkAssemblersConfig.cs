using Jobs.Api.Common.LinkAssembler;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.LinkAssemblers;

namespace Jobs.Core.Data.Config;

public static class LinkAssemblersConfig
{
    public static void RegisterLinkAssemblers(this IServiceCollection services)
    {
        services.AddScoped<ILinkAssembler<JobDetailResponseDto>, JobDetailLinkAssembler>();
        services.AddScoped<ILinkAssembler<JobResponseDto>, JobSummaryLinkAssembler>();
    }
}