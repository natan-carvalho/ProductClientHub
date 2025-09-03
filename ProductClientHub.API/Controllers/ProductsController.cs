using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
  [Route("api/products")]
  [ApiController]
  public class ProductsController(RegisterProductUseCase registerProductUseCase) : ControllerBase
  {
    private readonly RegisterProductUseCase _registerProductUseCase = registerProductUseCase;

    [HttpPost]
    [Route("{clientId}")]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
    {
      var response = _registerProductUseCase.Execute(clientId, request);
      return Created(string.Empty, response);
    }
  }
}
