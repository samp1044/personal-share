namespace FileShare.Main.Authentication.Web;

public record AuthenticationWebConfig
{
    public required CookieOptions CookieOptions { get; init; }
    public required string AuthenticationTokenHeader { get; init; }
}