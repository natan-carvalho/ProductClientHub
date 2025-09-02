using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update;

public class UpdateClientUseCase(ProductClientHubDbContext dbContext)
{
  public readonly ProductClientHubDbContext _dbContext = dbContext;

  public void Execute(Guid id, RequestClientJson request)
  {
    Validate(request);

    var client = _dbContext.Clients.FirstOrDefault(client => client.Id == id) ?? throw new NotFoundException("Client não encontrado.");

    client.Name = request.Name;
    client.Email = request.Email;

    _dbContext.Clients.Update(client);
    _dbContext.SaveChanges();
  }

  private void Validate(RequestClientJson request)
  {
    var validator = new RequestClientValidator();
    var result = validator.Validate(request);

    if (!result.IsValid)
    {
      var erros = result.Errors.Select(failure => failure.ErrorMessage).ToList();
      throw new ErrorOnValidationException(erros);
    }
  }
}
