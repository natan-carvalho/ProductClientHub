using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure;

public class ProductClientHubDbContext(DbContextOptions<ProductClientHubDbContext> options) : DbContext(options)
{
  public DbSet<Client> Clients { get; set; } = default!;
  public DbSet<Product> Products { get; set; } = default!;
}
