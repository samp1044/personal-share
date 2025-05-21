namespace FileShare.Main.Authentication.WebApi.Cookie;

public record CookieOptions()
{
    public required string Identifier { get; set; }
    public required bool HttpOnly { get; set; }
    public required string SameSite { get; set; }
    public required string SecurePolicy { get; set; }
}