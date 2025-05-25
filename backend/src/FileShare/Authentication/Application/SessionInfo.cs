namespace FileShare.Main.Authentication.Application;

public class SessionInfo
{
    public required string AuthToken { get; set; }
    public required DateTime ExpiresUtc { get; set;  }
}