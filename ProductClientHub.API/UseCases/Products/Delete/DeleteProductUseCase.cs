using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete;

public class DeleteProductUseCase(ProductClientHubDbContext productClientHubDbContext)
{
  private readonly ProductClientHubDbContext _productClientHubDbContext = productClientHubDbContext;

  public void Execute(Guid id)
  {
    var product = _productClientHubDbContext.Products.FirstOrDefault(product => product.Id == id) ?? throw new NotFoundException("Produto não encontrado.");
    _productClientHubDbContext.Products.Remove(product);
    _productClientHubDbContext.SaveChanges();
  }
}
