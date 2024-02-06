using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddDbContext<ApplicationDatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();