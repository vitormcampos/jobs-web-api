using Jobs.Core.Repositories.Jobs;
using Jobs.Core.Repositories.Users;

namespace Jobs.Core.Data.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}