using Todo.Domain.Commands.Contracts;
namespace Todo.Domain.Commands;

public class CreateTodoCommand : ICommand
{
    #region Constructors

    public CreateTodoCommand() { }


    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    #endregion

    #region Properties

    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }

    #endregion

    #region Methods

    public bool Validate(out List<string> validationsErrors)
    {
        bool valid = true;
        validationsErrors = new List<string>();

        if (Title.Length < 3)
        {
            validationsErrors.Add("O tamanho do título deve ser maior que 3 carácter");
            valid = false;
        }
            
        if(User.Length < 6)
        {
            validationsErrors.Add("O tamanho do usuário deve ser maior que 6 carácter");
            valid = false;
        }

        return valid;
    }

    #endregion
}