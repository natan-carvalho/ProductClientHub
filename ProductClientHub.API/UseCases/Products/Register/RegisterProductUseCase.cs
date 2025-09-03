using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Products.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Register;

public class RegisterProductUseCase(ProductClientHubDbContext dbContext)
{
  private readonly ProductClientHubDbContext _dbContext = dbContext;

  public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
  {
    Validate(clientId, request);

    var product = new Product
    {
      Name = request.Name,
      Brand = request.Brand,
      Price = request.Price,
      ClientId = clientId,
    };

    _dbContext.Products.Add(product);
    _dbContext.SaveChanges();

    return new ResponseShortProductJson
    {
      Id = product.Id,
      Name = product.Name,
    };
  }

  private void Validate(Guid clientId, RequestProductJson request)
  {
    var clientExist = _dbContext.Clients.Any(client => client.Id == clientId);
    if (!clientExist)
    {
      throw new NotFoundException("Cliente não exite");
    }

    var validator = new RequestProductValidator();
    var result = validator.Validate(request);

    if (!result.IsValid)
    {
      var erros = result.Errors.Select(failure => failure.ErrorMessage).ToList();
      throw new ErrorOnValidationException(erros);
    }
  }
}
