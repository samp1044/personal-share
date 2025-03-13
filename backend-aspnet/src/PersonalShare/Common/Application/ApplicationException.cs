namespace PersonalShare.Common.Application;

public abstract class ApplicationException: Exception
{
    public string ExceptionCode { get; }
    public string ExceptionMessage { get; }

    protected ApplicationException(string code, string message)
    {
        ExceptionCode = code;
        ExceptionMessage = message;
    }
}