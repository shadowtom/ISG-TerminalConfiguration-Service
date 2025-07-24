using ISG.TerminalConfiguration.Api.Extention;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
Console.WriteLine($"Environment: {environment}");

if (string.IsNullOrEmpty(environment))
{
    Console.WriteLine("INFO: Environment variable not setted (ASPNETCORE_ENVIRONMENT)");
    Console.WriteLine("Default Environment: Development");
    environment = "Development";
}

builder.Configuration.AddJsonFile("appsettings.json", optional: true);
builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: true);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TerminalConfigurations API",
        Version = "v1",
        Description = "API for requesting, modifying, and retrieving terminal configuratons",
        Contact = new OpenApiContact
        {
            Name = "Tomas Felipe Castrillon Loaiza",
            Email = "tomas@devbuddy.io"
        }
    });
});
builder.Services.AddProjectDependencies(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
