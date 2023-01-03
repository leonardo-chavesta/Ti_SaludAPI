using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infraestructure.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregando el context Data Base
builder.Services.AddDbContext<ApplicationDbContext>();
// Configuracion de la inyeccion de depencias
// builder.Services.AddScoped<ITipoEmpleadoRepository, TipoEmpleadoRepository>();
// builder.Services.AddScoped<ITipoEmpleadoService, TipoEmpleadoService>();

// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterAssemblyTypes(Assembly.Load("Infraestructure"))
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

        options.RegisterAssemblyTypes(Assembly.Load("Application"))
       .Where(t => t.Name.EndsWith("Service"))
       .AsImplementedInterfaces()
       .InstancePerLifetimeScope();
    });

builder.Services.AddAutoMapper(Assembly.Load("Application"));

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
