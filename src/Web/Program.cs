var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.AddWebServices();

var app = builder.Build();

app.UseHealthChecks("/health");
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllers();

app.Run();
