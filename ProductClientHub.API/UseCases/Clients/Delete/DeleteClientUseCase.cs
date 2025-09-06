using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Delete;

public class DeleteClientUseCase(ProductClientHubDbContext productClientHubDbContext)
{
  private readonly ProductClientHubDbContext _productClientHubDbContext = productClientHubDbContext;

  public void Execute(Guid id)
  {
    var client = _productClientHubDbContext.Clients.FirstOrDefault(client => client.Id == id) ?? throw new NotFoundException("Cliente não encontrado.");
    _productClientHubDbContext.Clients.Remove(client);
    _productClientHubDbContext.SaveChanges();
  }
}
