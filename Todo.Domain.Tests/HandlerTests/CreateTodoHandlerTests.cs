using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

public class CreateTodoHandlerTests
{
    #region Privates

    private readonly CreateTodoCommand _invalidCommand;
    private readonly CreateTodoCommand _validCommand;
    private readonly TodoItemHandler _handler;
    private List<string> errors = new();

    #endregion

    #region Constructors

    public CreateTodoHandlerTests()
    {
        _invalidCommand = new CreateTodoCommand("Ab", "Tiago", DateTime.Now);
        _validCommand = new CreateTodoCommand("Estudar.Net 7", "Thiago", DateTime.Now);
        _handler = new TodoItemHandler(new TodoFakeRepository());
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenACommandIsValid()
    {
        var result = (CommandResult)_handler.Handle(_validCommand);

        Assert.True(result.Success);
    }

    [Fact]
    public void WhenACommandIsInvalid()
    {
        var result = (CommandResult)_handler.Handle(_invalidCommand);

        Assert.True(!result.Success);
    }

    #endregion
}