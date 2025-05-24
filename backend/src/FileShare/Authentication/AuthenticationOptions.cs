using CookieOptions = FileShare.Main.Authentication.WebApi.Middleware.CookieOptions;

namespace FileShare.Main.Authentication;
public record AuthenticationOptions
{
    public required CookieOptions CookieOptions { get; init; }
}