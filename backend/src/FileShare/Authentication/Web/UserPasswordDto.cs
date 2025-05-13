namespace FileShare.Main.Authentication.Web;

public record UserPasswordDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}