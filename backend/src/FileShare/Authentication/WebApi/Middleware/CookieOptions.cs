namespace FileShare.Main.Authentication.WebApi.Middleware;

public record CookieOptions()
{
    public required string Name { get; set; }
    public required bool HttpOnly { get; set; }
    public required string SameSite { get; set; }
    public required string SecurePolicy { get; set; }
}