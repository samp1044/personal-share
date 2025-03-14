namespace PersonalShare.Features.Authentication.Service;

public class AuthenticationSessionService: IAuthenticationService
{
    public Task<AuthenticationResult> AuthenticateAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticationResult> AuthenticateAsync(string token)
    {
        throw new NotImplementedException();
    }
}