using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Data;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1")]
public class TodoController : ControllerBase
{
    #region Methods

    [HttpPost("todos")]
    public IActionResult Post([FromBody] CreateTodoCommand todo
    , [FromServices] TodoItemHandler handler)
    {
        try
        {
            handler.Handle(todo);
            return Ok(new CommandResult(true, "Registro salvo com sucesso.", todo));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, todo));
        }
    }

    #endregion
}