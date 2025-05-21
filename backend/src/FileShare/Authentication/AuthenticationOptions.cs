using CookieOptions = FileShare.Main.Authentication.WebApi.Cookie.CookieOptions;

namespace FileShare.Main.Authentication;
public record AuthenticationOptions
{
    public required CookieOptions CookieOptions { get; init; }
}