using Microsoft.AspNetCore.Mvc;

namespace ProductClientHub.API.Controllers;

[Route("/health")]
[ApiController]
public class Health : ControllerBase
{
  [HttpGet]
  public IActionResult Get() => Ok(new { status = "Healthy" });
}
