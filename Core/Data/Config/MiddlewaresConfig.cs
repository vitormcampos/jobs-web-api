using Jobs.Core.Middlewares;

namespace Jobs.Core.Data.Config;

public static class MiddlewaresConfig
{
    public static void RegisterMiddlewares(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}