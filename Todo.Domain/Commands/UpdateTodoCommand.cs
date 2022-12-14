using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : ICommand
{
    #region Contructors

    public UpdateTodoCommand() { }

    public UpdateTodoCommand(Guid id, string user, string title)
    {
        Id = id;
        Title = title;
        User = user;
    }

    #endregion

    #region Properties

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    #endregion

    #region Methods

    public bool Validate(out List<string> validationsErrors)
    {
        bool valid = true;
        validationsErrors = new List<string>();

        if (Title.Length < 3)
        {
            validationsErrors.Add("O tamanho título deve ser maior que 3 carácter");
            valid = false;
        }

        if (User.Length < 6)
        {
            validationsErrors.Add("O tamanho do usuário deve ser maior que 6 carácter");
            valid = false;
        }

        return valid;
    }

    #endregion
}