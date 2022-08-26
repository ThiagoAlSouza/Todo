using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoItemHandler : IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
{
    #region Private

    private readonly ITodoRepository _todoRepository;
    private List<string> errors = new();

    #endregion

    #region Contructors

    public TodoItemHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    #endregion

    #region Methods

    public ICommandResult Handle(CreateTodoCommand command)
    {
        if (!command.Validate(out errors))
            return new CommandResult(false, "Os dados de entrada estão inválidos.", errors);

        var todo = new TodoItem(command.Title, command.User, command.Date);

        _todoRepository.Create(todo);

        return new CommandResult(true, "Registro salvo com sucesso", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        if (!command.Validate(out errors))
            return new CommandResult(false, "Os dados de entrada estão inválidos.", errors);

        var todo = _todoRepository.GetById(command.Id);
        todo.UpdateTitle(command.Title);

        _todoRepository.Update(todo);

        return new CommandResult(true, "Registro salvo com sucesso", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        if (!command.Validate(out errors))
            return new CommandResult(false, "Os dados de entrada estão inválidos.", errors);

        var todo = _todoRepository.GetById(command.Id);
        todo.MarkAsDone(true);

        _todoRepository.Update(todo);

        return new CommandResult(true, "Registro salvo com sucesso", todo);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        if (!command.Validate(out errors))
            return new CommandResult(false, "Os dados de entrada estão inválidos.", errors);

        var todo = _todoRepository.GetById(command.Id);
        todo.MarkAsDone(false);

        _todoRepository.Update(todo);

        return new CommandResult(true, "Registro salvo com sucesso", todo);
    }

    #endregion
}