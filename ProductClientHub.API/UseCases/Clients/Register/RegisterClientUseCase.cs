using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
  public ResponseClientJson Execute(RequestClientJson request)
  {
    var validator = new RegisterClientValidator();
    var result = validator.Validate(request);

    if (!result.IsValid)
    {
      var erros = result.Errors.Select(failure => failure.ErrorMessage).ToList();
      throw new ErrorOnValidationException(erros);
    }
    return new ResponseClientJson();
  }
}
