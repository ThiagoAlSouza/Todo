using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    #region Methods

    ICommandResult Handle(T command);

    #endregion
}