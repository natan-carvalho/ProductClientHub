using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Filters;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.GetById;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.API.UseCases.Products.Delete;
using ProductClientHub.API.UseCases.Products.Register;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddScoped<RegisterClientUseCase, RegisterClientUseCase>();
builder.Services.AddScoped<GetAllClientsUseCase, GetAllClientsUseCase>();
builder.Services.AddScoped<UpdateClientUseCase, UpdateClientUseCase>();
builder.Services.AddScoped<DeleteClientUseCase, DeleteClientUseCase>();
builder.Services.AddScoped<GetClientByIdUseCase, GetClientByIdUseCase>();

builder.Services.AddScoped<RegisterProductUseCase, RegisterProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter))); // adding filters
builder.Services.AddDbContext<ProductClientHubDbContext>(options =>
  options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();