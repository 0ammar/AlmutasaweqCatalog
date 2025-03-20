using AlmutasaweqCatalog.DbContexts;
using AlmutasaweqCatalog.Implementations;
using AlmutasaweqCatalog.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogContext>(x => x.UseSqlServer("Data Source=AMMAR-ARAB\\SQLEXPRESS;" +
	"Initial Catalog=AlmutasaweqCatalog;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddScoped<IReadServices, ReadServices>();

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
