namespace Jobs.Core.Data.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}