namespace FileShare.Main.Authentication.AuthenticationService;

public interface IAuthenticationService
{
    public Task AuthenticateAsync(string user, string password);
}