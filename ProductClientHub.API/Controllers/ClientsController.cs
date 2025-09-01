using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
  private readonly RegisterClientUseCase _registerUseCase;

  public ClientsController(RegisterClientUseCase registerUseCase)
  {
    _registerUseCase = registerUseCase;
  }

  [HttpPost]
  [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
  public IActionResult Register([FromBody] RequestClientJson request)
  {
    var response = _registerUseCase.Execute(request);
    return Created(string.Empty, response);
  }

  [HttpPut]
  public IActionResult Update()
  {
    return Ok();
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok();
  }

  [HttpGet]
  [Route("{id}")]
  public IActionResult GetById(Guid id)
  {
    return Ok();
  }

  [HttpDelete]
  public IActionResult Delete()
  {
    return Ok();
  }
}
