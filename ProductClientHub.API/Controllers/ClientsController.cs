using Microsoft.AspNetCore.Mvc;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
  public IActionResult Register([FromBody] RequestClientJson request)
  {
    return Created();
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
