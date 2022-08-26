using Microsoft.AspNetCore.Mvc;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1")]
public class StatusApiController : ControllerBase
{
    #region Methods

    [HttpGet("status-api")]
    public IActionResult Get()
    {
        return Ok();
    }

    #endregion
}
