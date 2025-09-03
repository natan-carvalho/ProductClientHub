using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController(RegisterClientUseCase registerUseCase, GetAllClientsUseCase getAllClientsUseCase, UpdateClientUseCase updateClientUseCase) : ControllerBase
{
  private readonly RegisterClientUseCase _registerUseCase = registerUseCase;
  private readonly GetAllClientsUseCase _getAllClientsUseCase = getAllClientsUseCase;
  private readonly UpdateClientUseCase _updateClientUseCase = updateClientUseCase;

  [HttpPost]
  [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
  public IActionResult Register([FromBody] RequestClientJson request)
  {
    var response = _registerUseCase.Execute(request);
    return Created(string.Empty, response);
  }

  [HttpPut]
  [Route("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
  public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
  {
    _updateClientUseCase.Execute(id, request);
    return NoContent();
  }

  [HttpGet]
  [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult GetAll()
  {
    var response = _getAllClientsUseCase.Execute();

    if (response.Clients.Count == 0)
    {
      return NoContent();
    }

    return Ok(response);
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
