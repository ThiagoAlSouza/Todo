using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class MarkTodoAsDoneCommand : ICommand
{
    #region Contructors

    public MarkTodoAsDoneCommand() { }

    public MarkTodoAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    #endregion

    #region Properties

    public Guid Id { get; set; }
    public string User { get; set; }

    #endregion

    #region Methods

    public bool Validate(out List<string> validationsErrors)
    {
        bool valid = true;
        validationsErrors = new List<string>();

        if (User.Length < 6)
        {
            validationsErrors.Add("O tamanho do usuário deve ser maior que 6 carácter");
            valid = false;
        }

        return valid;
    }

    #endregion
}