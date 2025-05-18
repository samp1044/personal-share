using FileShare.Main.Shared;

namespace FileShare.Main.Authentication;

public interface IAuthenticationProvider
{
    Task<Result<AuthenticationTicket>> AuthenticateAsync(string email, string password);
}

public record AuthenticationTicket(string UserId);