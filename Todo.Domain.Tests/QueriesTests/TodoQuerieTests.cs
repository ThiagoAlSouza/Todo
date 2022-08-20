using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests;

public class TodoQuerieTests
{
    #region Private

    private readonly List<TodoItem> _todoItems = new();

    #endregion

    #region Constructors

    public TodoQuerieTests()
    {
        _todoItems.Add(new TodoItem("Estudar .Net 7", "Thiago", DateTime.Now));
        _todoItems.Add(new TodoItem("Estudar Angular", "Thiago", DateTime.Now.AddMonths(1)));
        _todoItems.Add(new TodoItem("Estudar Flutter", "Thiago Alves", DateTime.Now.AddMonths(2)));
        _todoItems.Add(new TodoItem("Estudar DevOps", "Thiago", DateTime.Now.AddMonths(3)));
        _todoItems.Add(new TodoItem("Estudar Micro-serviços", "Thiago Alves", DateTime.Now.AddMonths(4)));
    }

    #endregion

    #region Methods

    [Fact]
    public void SearchOnlyUserTodo()
    {
        var result = _todoItems.AsQueryable().Where(TodoQueries.GetAll("Thiago"));

        Assert.Equal(3, result.Count());
    }

    #endregion
}