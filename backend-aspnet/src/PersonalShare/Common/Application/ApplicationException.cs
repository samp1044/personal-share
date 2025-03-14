namespace PersonalShare.Common.Application;

public abstract class ApplicationException: Exception
{
    public string ErrorCode { get; }

    protected ApplicationException(string code, string message): base(message)
    {
        ErrorCode = code;
    }
}