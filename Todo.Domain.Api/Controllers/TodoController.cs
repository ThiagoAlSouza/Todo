using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1")]
public class TodoController : ControllerBase
{
    #region Private

    private readonly ITodoRepository _todoRepository;

    #endregion

    #region Constructors

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    #endregion

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

    [HttpGet("todos")]
    public IActionResult Get()
    {
        try
        {
            var todos = _todoRepository.GetAll();

            return Ok(new CommandResult(true, string.Empty, todos));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, null));
        }
    }

    [HttpGet("get-all-undone/{user}")]
    public IActionResult GetAllDone([FromRoute] string user)
    {
        try
        {
            var todos = _todoRepository.GetAllDone(user);

            return Ok(new CommandResult(true, string.Empty, todos));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, null));
        }
    }

    [HttpGet("get-all-done/{user}")]
    public IActionResult GetAllUnDone([FromRoute] string user)
    {
        try
        {
            var todos = _todoRepository.GetAllUndone(user);

            return Ok(new CommandResult(true, string.Empty, todos));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, null));
        }
    }

    [HttpPut("todos")]
    public IActionResult Update([FromBody] UpdateTodoCommand todo,
        [FromServices] TodoItemHandler handler)
    {
        try
        {
            handler.Handle(todo);
            return Ok(new CommandResult(true, "Registro atualizado com sucesso.", todo));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, todo));
        }
    }

    [HttpPut("mark-as-done")]
    public IActionResult MarkAsDone(
        [FromBody] MarkTodoAsDoneCommand todo,
        [FromServices] TodoItemHandler handler
    )
    {
        try
        {
            handler.Handle(todo);
            return Ok(new CommandResult(true, "Ação realizada com sucesso.", todo));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, todo));
        }
    }

    [HttpPut("mark-as-undone")]
    public IActionResult MarkAsUndone(
        [FromBody] MarkTodoAsUndoneCommand todo,
        [FromServices] TodoItemHandler handler
    )
    {
        try
        {
            handler.Handle(todo);
            return Ok(new CommandResult(true, "Ação realizada com sucesso.", todo));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, todo));
        }
    }

    [HttpGet("get-by-period/{user,date}")]
    public IActionResult GetByPeriod([FromRoute]string user,
        [FromRoute]DateTime date)
    {
        try
        {
            var todos = _todoRepository.GetByPeriod(user, date, true);

            return Ok(new CommandResult(true, string.Empty, todos));
        }
        catch (Exception e)
        {
            return BadRequest(new CommandResult(false, e.Message, null));
        }
    }

    #endregion
}