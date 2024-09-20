using CatalogApi.Context;
using CatalogApi.Extensions;
using CatalogApi.Filters;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


DotEnv.Load();

string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_MYSQL");

builder.Services.AddDbContext<CADbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<ApiLoggingFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ConfigureExceptionHandler();
    app.ConfigureExceptionHandler();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
