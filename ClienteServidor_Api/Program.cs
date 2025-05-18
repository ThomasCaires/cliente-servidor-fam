using ClienteServidor_Api.Data;
using ClienteServidor_Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICarRepository, CarRepository>();

//builder.Services.AddScoped();
builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(e => e.MapControllers());

app.MapGet("/", () => "Hello World!");

app.Run();
