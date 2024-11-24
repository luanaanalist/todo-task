using ToDoApp.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using ToDoApp.Api.Middlewares;
using ToDoApp.Application.Mapping;
using ToDoApp.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Hosting;
using ToDoApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(ValidateModelStateFilterAttribute));
    opt.Filters.Add(typeof(CustomException));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

builder.Services.ConfigureDependencyInjection();

var app = builder.Build();

app.MigrateDatabase();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty;
});


app.UseAuthorization();
app.MapControllers();
app.UsePathBase("/api");
app.UseDefaultFiles();
app.Run();
