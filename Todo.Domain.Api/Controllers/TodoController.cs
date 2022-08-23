﻿using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Data;
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

            return Ok(new CommandResult(true, "Registro salvo com sucesso.", todos));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}