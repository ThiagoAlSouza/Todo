using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

public class CreateTodoCommandTests
{
    #region Privates

    private readonly CreateTodoCommand _invalidCommand;
    private readonly CreateTodoCommand _validCommand;
    private List<string> errors = new();

    #endregion

    #region Constructors

    public CreateTodoCommandTests()
    {
        _invalidCommand = new CreateTodoCommand("Ab", "Tiago", DateTime.Now);
        _validCommand = new CreateTodoCommand("Estudar.Net 7", "Thiago", DateTime.Now);
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenACommandIsValid()
    {
        Assert.True(_validCommand.Validate(out errors));
    }

    [Fact]
    public void WhenACommandIsInvalid()
    {
        Assert.True(!_invalidCommand.Validate(out errors));
    }

    #endregion
}