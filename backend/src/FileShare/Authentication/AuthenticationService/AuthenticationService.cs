namespace FileShare.Main.Authentication.AuthenticationService;

public class AuthenticationService(IAuthenticationProvider authenticationProvider, ISession session)
    : IAuthenticationService
{
    public async Task AuthenticateAsync(string user, string password)
    {
        var authenticationTicket = await authenticationProvider.AuthenticateAsync(user, password);
        await session.CreateAsync(authenticationTicket);
    }
}