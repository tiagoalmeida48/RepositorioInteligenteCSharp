using Dominio.Interfaces;
using Dominio.InterfacesServicos;
using Dominio.Servico;
using Microsoft.EntityFrameworkCore;
using Repositorio.Configuracoes;
using Repositorio.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>(option =>
    option.UseMySql("Server = localhost; Database = REPOSITORIO_INTELIGENTE; Uid = root; Pwd = 16011991; ", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27 - mysql"))
);

builder.Services.AddSingleton(typeof(IGenerica<>), typeof(RepositorioGenerico<>));
builder.Services.AddSingleton<IUsuario, RepositorioUsuario>();
builder.Services.AddSingleton<IUsuarioServico, UsuarioServico>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
