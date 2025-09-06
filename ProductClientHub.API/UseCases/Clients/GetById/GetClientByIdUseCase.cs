using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetById;

public class GetClientByIdUseCase(ProductClientHubDbContext productClientHubDbContext)
{
  private readonly ProductClientHubDbContext _productClientHubDbContext = productClientHubDbContext;

  public ResponseClientJson Execute(Guid id)
  {
    var client = _productClientHubDbContext
      .Clients
      .Include(client => client.Products)
      .FirstOrDefault(c => c.Id == id) ?? throw new KeyNotFoundException("Cliente não encontrado.");

    return new ResponseClientJson
    {
      Id = client.Id,
      Name = client.Name,
      Email = client.Email,
      Products = [.. client.Products.Select(product => new ResponseShortProductJson
      {
        Id = product.Id,
        Name = product.Name,
      })]
    };
  }
}
