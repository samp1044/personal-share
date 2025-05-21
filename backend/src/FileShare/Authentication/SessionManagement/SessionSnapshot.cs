namespace FileShare.Main.Authentication.SessionManagement;

public record SessionSnapshot
{
    public required string Id { get; init; }
    public required DateTime ExpiresUtc { get; init; }
    public required string UserId { get; init; }
}