using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Data;
using Todo.Domain.Queries;
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
        try
        {
           var todo = _context.Todos.FirstOrDefault(x => x.Id == id);

           if (todo == null)
               throw new Exception("Registro não encontrado.");

           return todo;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public IEnumerable<TodoItem> GetAll()
    {
        try
        {
            var todos = _context.Todos.AsNoTracking().ToList();

            return todos;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public IEnumerable<TodoItem> GetAllByUser(string user)
    {
        try
        {
            var todos = _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAll(user));

            return todos;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    } 

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        try
        {
            var todosUndone = _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllUnDone(user));

            return todosUndone;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        try
        {
            var todosDone = _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllDone(user));

            return todosDone;   

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        try
        {
            var todosDone = _context.Todos.AsNoTracking()
                .Where(x => x.User == user &&
                            x.Done == done &&
                            x.Date.Date == date.Date);

            return todosDone;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    #endregion
}