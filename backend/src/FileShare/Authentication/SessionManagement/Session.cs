namespace FileShare.Main.Authentication.SessionManagement;

public class Session(ISessionRepository sessionRepository) : ISession
{
    private ISessionRepository _sessionRepository = sessionRepository;

    public bool IsActive { get; } = false;
    public AuthenticationId AuthenticationId { get; }
    public DateTime ExpiresUtc { get; }
    
    public Task LoadAsync(AuthenticationId authentication)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(AuthenticationTicket authenticationTicket)
    {
        throw new NotImplementedException();
    }
}