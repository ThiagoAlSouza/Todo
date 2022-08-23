using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    #region Methods

    void Create(TodoItem todo);
    void Update(TodoItem todo);
    TodoItem GetById(Guid id);
    IEnumerable<TodoItem> GetAll(string user);
    IEnumerable<TodoItem> GetAllUndone(string user);
    IEnumerable<TodoItem> GetAllDone(string user);
    IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);

    #endregion
}