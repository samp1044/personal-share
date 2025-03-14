namespace PersonalShare.Common.Application;

public class UnauthenticatedException: ApplicationException
{
    public UnauthenticatedException(string code, string message) : base(code, message)
    {
    }
}