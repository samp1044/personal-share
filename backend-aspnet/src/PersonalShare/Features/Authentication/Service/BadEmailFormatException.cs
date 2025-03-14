using PersonalShare.Common.Application;

namespace PersonalShare.Features.Authentication.Service;

public class BadEmailFormatException: ValidationException
{
    public BadEmailFormatException() : base("BAD_EMAIL_FORMAT", "The provided email address is in invalid format")
    {
    }
}