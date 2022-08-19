using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Domain.Tests.HandlerTests;

public class CreateTodoHandlerTests
{
    #region Privates

    private readonly CreateTodoCommand _invalidCommand;
    private readonly CreateTodoCommand _validCommand;
    private List<string> errors = new();

    #endregion

    #region Constructors

    public CreateTodoHandlerTests()
    {
        _invalidCommand = new CreateTodoCommand("Ab", "Tiago", DateTime.Now);
        _validCommand = new CreateTodoCommand("Estudar.Net 7", "Thiago", DateTime.Now);
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenACommandIsValid()
    {
        Assert.True(true);
    }

    [Fact]
    public void WhenACommandIsInvalid()
    {
        Assert.True(true);
    }

    #endregion
}