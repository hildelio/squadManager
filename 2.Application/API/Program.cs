using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Repository.Context;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner de injeção de dependência.
builder.Services.AddScoped<UserRepository>(); // Registra a UserRepository como um serviço de escopo
builder.Services.AddScoped<UserService>();   // Registra o UserService como um serviço de escopo

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "User API",
        Description = "An ASP.NET Core Web API for managing Users",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // Configuração para incluir os comentários XML da documentação
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// String de conexão diretamente aqui
var connectionString = "Server=localhost,1433;Database=squadmanagerdb;User Id=sa;Password=MinhaSenha@123;TrustServerCertificate=true;";

// Adiciona o DbContext como um serviço, configurado para usar o SQL Server
builder.Services.AddDbContext<EFContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("API"));
});

builder.Services.AddControllers();

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI();
}

// Configura o CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Redireciona requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita o roteamento de requisições
app.UseRouting();

// Mapeia os controllers
app.MapControllers();

app.Run();
