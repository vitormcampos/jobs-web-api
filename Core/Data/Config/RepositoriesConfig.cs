using Jobs.Core.Repositories.Jobs;

namespace Jobs.Core.Data.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
    }
}