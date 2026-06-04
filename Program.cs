using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opciones => //CORS (CROSS ORIGIN RESOURCE SHARING) es una medida de seguridad de los navegadores para evitar peticiones de un puerto distinto al de la pagina
{
    opciones.AddPolicy("PermitirReact", app =>
    {
        app.AllowAnyOrigin() //Cuaalquierorigen permite que cualquier página web se conecte 
        .AllowAnyHeader() //Permite cualquier tipo de dato
        .AllowAnyMethod(); //Permite cualquier método (GET, POST, PUT, DELETE)
    });
});

builder.Services.AddDbContext<PasteleriaContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionPasteleria")); //"ConexionPasteleria es la variable de entorno de appsettings.json
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirReact"); //Añadir/Cambiar Cors es un paso importante para poder conectar puertos distintos, es decir,
//conectar nuestro Backend(ASP.NET) con nuestro Frontend(React)

app.UseAuthorization();

app.MapControllers();

app.Run();
