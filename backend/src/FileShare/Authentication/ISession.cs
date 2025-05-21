using FileShare.Main.Authentication.SessionManagement;
using FileShare.Main.Shared;

namespace FileShare.Main.Authentication;

public interface ISession
{
    public AuthenticationId AuthenticationId { get; }
    public DateTime ExpiresUtc { get; }
    public string UserId { get; }
}

internal interface ISessionService: ISession
{
    public bool IsActive { get; }
    
    /// <summary>
    /// Retrieves the current active session
    /// </summary>
    /// <exception cref="UnauthenticatedException">If no session is active</exception>
    public ISession Get();
    
    /// <summary>
    /// Load the session associated with some authentication info, if any. 
    /// </summary>
    /// <param name="authentication">The authentication info to load a session for</param>
    /// <exception cref="UnauthenticatedException">If no session can be loaded based on the provided authentication info</exception>
    public Task LoadAsync(AuthenticationId authentication);

    /// <summary>
    /// Create a new session based on the received authentication ticket
    /// </summary>
    /// <param name="ticket">The ticket to base the new session on</param>
    public Task CreateAsync(AuthenticationTicket ticket);
}