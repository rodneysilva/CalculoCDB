using CalculoCDB.Application.Services.CDBService;
using CalculoCDB.Domain.Interfaces.CalculoService;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHealthChecks();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ICalculoService, CalculoService>();
        builder.Services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "CalculoCDB API";

        });
    }
}
