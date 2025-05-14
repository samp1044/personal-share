namespace FileShare.Main.Authentication.SessionManagement;

public record SessionSnapshot
{
    public required Guid Id { get; init; }
    public required DateTime ExpiresUtc { get; init; }
    public required string UserId { get; init; }
}