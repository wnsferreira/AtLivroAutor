using System.Text.Json.Serialization;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CursoDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CursoDbContextConnection' not found.");

builder.Services
    .AddDbContext<AtDbContext>(options => options.UseSqlServer(connectionString));


builder.Services
    .AddControllers()
    .AddJsonOptions(configure =>
    {
        configure.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddTransient<ILivroService, LivroService>();
builder.Services.AddTransient<IAutorService, AutorService>();

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

