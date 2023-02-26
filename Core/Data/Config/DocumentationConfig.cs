using Microsoft.OpenApi.Models;

namespace Jobs.Core.Data.Config;

public static class DocumentationConfig
{
    public static void RegisterDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Jobs",
                    Description = "API para trabalhar com vagas de jobs",
                    Contact = new OpenApiContact
                    {
                        Name = "Vitor Campos",
                        Email = "vitormcampos99@gmail.com"
                    }
                }
            );
        });
    }
}