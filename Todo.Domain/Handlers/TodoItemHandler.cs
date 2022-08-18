using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoItemHandler : IHandler<CreateTodoCommand>
{
    #region Private

    private readonly ITodoRepository _todoRepository;

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
        var errors = new List<string>();

        if (!command.Validate(out errors))
            return new CommandResult(false, "Os dados de entrada estão inválidos.", errors);

        var todo = new TodoItem(command.Title, command.User, command.Date);

        _todoRepository.Create(todo);

        return new CommandResult(true, "Sucesso ao salvar", todo);
    }

    #endregion
}