namespace Todo.Domain.Entities;

public class TodoItem : BaseEntity
{
    #region Constructors

    public TodoItem(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Done = false;
        Date = date;
    }

    #endregion

    #region Properties

    public string Title { get; private set; }
    public bool Done { get; private set; }
    public string User { get; private set; }
    public DateTime Date { get; private set; }

    #endregion

    #region Methods

    public void MarkAsDone(bool done)
    {
        Done = done;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
    }

    #endregion
}