using AdocaoAnimais.Application.Interfaces;
using AdocaoAnimais.Application.Services;
using AdocaoAnimais.Domain.Interfaces;
using AdocaoAnimais.Infrastructure.Data;
using AdocaoAnimais.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration
        .GetConnectionString("Sqlite") ?? throw new InvalidOperationException("ConnectionString não encontrada.")));

builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalService, AnimalService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();