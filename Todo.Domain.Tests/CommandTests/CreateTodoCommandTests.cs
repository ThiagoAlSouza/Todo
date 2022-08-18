using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

public class CreateTodoCommandTests
{
    [Fact]
    public void WhenACommandIsValid()
    {
        var command = new CreateTodoCommand("Estudar.Net 7", "Thiago", DateTime.Now);
        var errors = new List<string>();

        Assert.True(command.Validate(out errors));
    }

    [Fact]
    public void WhenACommandIsInvalid()
    {
        var command = new CreateTodoCommand("Ab", "Tiago", DateTime.Now);
        var errors = new List<string>();

        Assert.True(!command.Validate(out errors));
    }
}