namespace FileShare.Main.Authentication.AuthenticationService;

public interface IAuthenticationProvider
{
    Task<AuthenticationTicket> AuthenticateAsync(string email, string password);
}