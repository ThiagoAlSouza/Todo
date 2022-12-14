using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class TodoFakeRepository : ITodoRepository
{
    #region Methods

    public void Create(TodoItem todo)
    {

    }

    public void Update(TodoItem todo)
    {

    }

    public TodoItem GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllByUser(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }

    #endregion
}