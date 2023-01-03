using Application.Services.Abstractions;
using Application.Services.Implementations;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstracions;
using Infraestructure.Repositories.Implementacions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregando el context Data Base
builder.Services.AddDbContext<ApplicationDbContext>();
// Configuracion de la inyeccion de depencias
builder.Services.AddScoped<ITipoEmpleadoRepository, TipoEmpleadoRepository>();
builder.Services.AddScoped<ITipoEmpleadoService, TipoEmpleadoService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
