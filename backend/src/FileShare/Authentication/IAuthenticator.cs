namespace FileShare.Main.Authentication;

public interface IAuthenticator
{
    Task<IAuthenticationToken> AuthenticateAsync(string email, string password);
}