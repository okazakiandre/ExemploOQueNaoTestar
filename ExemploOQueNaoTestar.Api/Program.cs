using ExemploOQueNaoTestar.Api.Application.Connectors;
using ExemploOQueNaoTestar.Api.Infra;
using ExemploOQueNaoTestar.Api.Infra.Repositories;
using ExemploOQueNaoTestar.Api.Infra.SeedWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddSingleton<IMongoDbContext, PedidoDbContext>();
builder.Services.AddScoped<IPedidoInput, PedidoRepository>();
builder.Services.AddScoped<IProdutoInput, ProdutoApiClient>();

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
