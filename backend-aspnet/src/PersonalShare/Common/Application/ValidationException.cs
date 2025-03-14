namespace PersonalShare.Common.Application;

public class ValidationException: ApplicationException
{
    public ValidationException(string code, string message) : base(code, message)
    {
    }
}