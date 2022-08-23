using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Data;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    #region Private

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public void Create(TodoItem todo)
    {
        if (todo == null)
            throw new ArgumentNullException("O objeto enviado está nulo.");

        try
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void Update(TodoItem todo)
    {
        if (todo == null)
            throw new ArgumentNullException("O objeto enviado está nulo.");

        try
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public TodoItem GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAll(string user)
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