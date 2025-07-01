using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace WebUI.Server.Extensions;

public static class AspNetExtensions
{
    public static void AddAspNetCore(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpContextAccessor();
        services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(config["BaseUri"]!)
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "Authorization"
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }
}
