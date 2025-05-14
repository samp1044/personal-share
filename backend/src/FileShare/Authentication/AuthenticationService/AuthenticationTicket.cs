namespace FileShare.Main.Authentication.AuthenticationService;

public record AuthenticationTicket
{
    public required string UserId { get; init; }
}