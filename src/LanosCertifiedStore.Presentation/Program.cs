using LanosCertifiedStore.Application;
using LanosCertifiedStore.Infrastructure;
using LanosCertifiedStore.Persistence;
using LanosCertifiedStore.Presentation;
using LanosCertifiedStore.Presentation.Extensions;
using LanosCertifiedStore.Presentation.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddExternalServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();
app.UseStaticFiles();

app.MapControllers();

await app.ExecuteMigration();

app.Run();

// For integration testing purposes
namespace LanosCertifiedStore.Presentation
{
    public partial class Program;
}