using Jobs.Api.Auth.Services;
using Jobs.Api.Common.Services;
using Jobs.Api.Jobs.Services;
using Jobs.Api.Users.Services;

namespace Jobs.Core.Data.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}