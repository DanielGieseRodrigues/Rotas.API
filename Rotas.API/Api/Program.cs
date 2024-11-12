using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Rotas.API.Application.UseCases.CalcularMelhorRota;
using Rotas.API.Application.UseCases.GerenciarRotas.AdicionarRotas;
using Rotas.API.Application.UseCases.GerenciarRotas.EditarRotas;
using Rotas.API.Application.UseCases.GerenciarRotas.ExcluirRota;
using Rotas.API.Application.UseCases.GerenciarRotas.ListarRotas;
using Rotas.API.Domain.Interfaces;
using Rotas.API.Infra.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RotaContext>(options => options.UseInMemoryDatabase("RotaDb"));
builder.Services.AddScoped<IRotaRepository, RotaRepository>();

// Adicionando os casos de usos
builder.Services.AddScoped<AdicionarRotaUseCase>();
builder.Services.AddScoped<CalcularMelhorRotaUseCase>();
builder.Services.AddScoped<ListarRotasUseCase>();
builder.Services.AddScoped<ExcluirRotaUseCase>();
builder.Services.AddScoped<EditarRotaUseCase>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RotaContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
