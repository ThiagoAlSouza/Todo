using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntitiesTests;

public class TodoTests
{
    #region Private

    private readonly TodoItem _todoItem;

    #endregion

    #region Constructor

    public TodoTests()
    {
        _todoItem = new TodoItem("Estudar .Net 7", "Thiago", DateTime.Now);
    }

    #endregion

    #region Methods

    [Fact]
    public void WhenCreateATodoDoneShouldBeFalse()
    {
        Assert.True(!_todoItem.Done);
    }


    #endregion
}