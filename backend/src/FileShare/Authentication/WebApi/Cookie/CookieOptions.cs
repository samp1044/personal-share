namespace FileShare.Main.Authentication.WebApi.Cookie;

public record CookieOptions()
{
    public required string Identifier { get; set; }
}