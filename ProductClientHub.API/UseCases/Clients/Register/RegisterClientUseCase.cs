using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase(ProductClientHubDbContext dbContext)
{
  private readonly ProductClientHubDbContext _dbContext = dbContext;

  public ResponseShortClientJson Execute(RequestClientJson request)
  {
    Validate(request);

    var entity = new Client
    {
      Name = request.Name,
      Email = request.Email
    };

    _dbContext.Clients.Add(entity);

    _dbContext.SaveChanges();

    return new ResponseShortClientJson
    {
      Id = entity.Id,
      Name = entity.Name,
    };
  }

  private void Validate(RequestClientJson request)
  {
    var validator = new RegisterClientValidator();
    var result = validator.Validate(request);

    if (!result.IsValid)
    {
      var erros = result.Errors.Select(failure => failure.ErrorMessage).ToList();
      throw new ErrorOnValidationException(erros);
    }
  }
}
