using Microsoft.AspNetCore.Mvc;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1")]
public class HealthController : ControllerBase
{
    [HttpGet("health")]
    public IActionResult Get()
    {
        return Ok();
    }
}
