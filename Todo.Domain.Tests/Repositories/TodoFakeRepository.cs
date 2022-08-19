using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class TodoFakeRepository : ITodoRepository
{
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
}