namespace Todo.Domain.Commands.Contracts;

public class CommandResult : ICommandResult
{
    #region Constructors

    public CommandResult() { }
    
    public CommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    #endregion

    #region Properties

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public Object Data { get; private set; }

    #endregion
}