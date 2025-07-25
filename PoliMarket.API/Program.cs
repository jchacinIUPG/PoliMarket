using PoliMarket.Services;
using PoliMarket.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// WARN: Añadir el resto de servicios como Singleton para poder mantener los datos en tiempo de ejecución para todas las solicitudes.
builder.Services.AddSingleton<IRH, RHService>();
builder.Services.AddSingleton<IBodega, BodegaService>();
builder.Services.AddSingleton<IVentas, VentasService>();

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
