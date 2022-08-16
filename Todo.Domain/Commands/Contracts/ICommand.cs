namespace Todo.Domain.Commands.Contracts;

public interface ICommand
{
    bool Validate(out List<string> validationsErrors);
}