using PersonalShare.Common.Application;

namespace PersonalShare.Features.Authentication.Service;

public class WrongCredentialsException: UnauthenticatedException
{
    public WrongCredentialsException() : base("WRONG_CREDENTIALS", "The provided user credentials do not match to a valid user")
    {
    }
}