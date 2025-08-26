using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
  public IActionResult Register([FromBody] RequestClientJson request)
  {
    try
    {
      var useCase = new RegisterClientUseCase();
      var response = useCase.Execute(request);
      return Created(string.Empty, response);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(new ResponseErrorMessagesJson(ex.Message));
    }
    catch
    {
      return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
    }
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
