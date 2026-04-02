using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados
builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Controllers + JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger sempre disponível (melhor pra estudo)
app.UseSwagger();
app.UseSwaggerUI();

// Middlewares
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();