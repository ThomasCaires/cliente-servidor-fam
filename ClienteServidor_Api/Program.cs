using ClienteServidor_Api.Data;
using ClienteServidor_Api.Data.Persistence;
using ClienteServidor_Api.Data.Persistence.JsonService;
using ClienteServidor_Api.Models;


/*
 * onde a aplica��o � inializada.
 * 
 * WebApplication.CreateBuilder(args) -> as configura��es iniciais e o gerenciamento do tempo de vida das dependencias sao configuradas
 * atraves desta instancia.
 * -> AddSingleton --> uma �nica inst�ncia do servi�o � criada e reutilizada durante a vida �til da aplica��o;
 * 
 * var app = builder.Build(); -> aqui � adicionado os endpoints, routing , controllers e tambem authentication/authorization que nao utilizamos no projeto
 * 
 */
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<JsonDataService>();

//builder.Services.AddScoped();
builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

//aqui estamos usando como endpoints os que sao informado no controller
app.UseEndpoints(e => e.MapControllers()); 

app.MapGet("/", () => "Api cliente servidor -->");

app.Run();
