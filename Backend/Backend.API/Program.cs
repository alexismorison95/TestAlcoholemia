using Backend.Application.Interfaces;
using Backend.Application.Services;
using Backend.Core.Repositories;
using Backend.Core.Repositories.Base;
using Backend.Infrastructure.DataContext;
using Backend.Infrastructure.Repositories;
using Backend.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TallerContext>(options => options.UseNpgsql(connectionString));

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//repo generico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//repos
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

//servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

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
