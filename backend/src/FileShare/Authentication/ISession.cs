using FileShare.Main.Authentication.AuthenticationService;
using FileShare.Main.Shared;

namespace FileShare.Main.Authentication;

public interface ISession
{
    public bool IsActive { get; }
    public AuthenticationInfo AuthenticationInfo { get; }
    public DateTime ExpiresUtc { get; }
    
    /// <summary>
    /// Load the session associated with some authentication info, if any. 
    /// </summary>
    /// <param name="info">The authentication info to load a session for</param>
    /// <exception cref="UnauthenticatedException">If no session can be loaded based on the provided authentication info</exception>
    public Task LoadAsync(AuthenticationInfo info);

    /// <summary>
    /// Create a new session based on the received authentication ticket
    /// </summary>
    /// <param name="ticket">The ticket to base the new session on</param>
    public Task CreateAsync(AuthenticationTicket ticket);
}