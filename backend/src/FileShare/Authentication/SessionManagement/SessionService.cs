using FileShare.Main.Authentication.AuthenticationService;

namespace FileShare.Main.Authentication.SessionManagement;

public class SessionService(ISessionRepository sessionRepository) : ISession
{
    private ISessionRepository _sessionRepository = sessionRepository;

    public bool IsActive { get; } = false;
    public AuthenticationInfo AuthenticationInfo { get; }
    public DateTime ExpiresUtc { get; }
    
    public Task LoadAsync(AuthenticationInfo info)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(AuthenticationTicket ticket)
    {
        throw new NotImplementedException();
    }
}