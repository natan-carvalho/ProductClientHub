using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Filters;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Register;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddScoped<RegisterClientUseCase, RegisterClientUseCase>();
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