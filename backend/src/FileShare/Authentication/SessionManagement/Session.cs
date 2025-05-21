using FileShare.Main.Shared;

namespace FileShare.Main.Authentication.SessionManagement;

public class Session(ISessionRepository sessionRepository) : ISessionService
{
    public bool IsActive { get; private set; } = false;
    
    private TimeSpan _lifeTime = TimeSpan.FromDays(10);

    public AuthenticationId AuthenticationId => Get().AuthenticationId;
    public DateTime ExpiresUtc { get; }
    public string UserId { get; }

    public ISession Get()
    {
        if (!IsActive)
        {
            throw new UnauthenticatedException();
        }

        return this;
    }
    
    public async Task LoadAsync(AuthenticationId authentication)
    {
        var snapshot = await sessionRepository.LoadAsync(authentication);

        if (snapshot == null)
        {
            throw new UnauthenticatedException();
        }

        if (snapshot.ExpiresUtc <= DateTime.UtcNow)
        {
            throw new UnauthenticatedException();
        }
        
        IsActive = true;
        AuthenticationId = AuthenticationId.Parse(snapshot.Id);
        ExpiresUtc = ExpireTime;
        _userId = snapshot.UserId;

        await sessionRepository.SaveAsync(snapshot with
        {
            ExpiresUtc = ExpiresUtc
        });
    }

    public async Task CreateAsync(AuthenticationTicket authenticationTicket)
    {
        var authenticationId = AuthenticationId.New();
        var expiresUtc = ExpireTime;
        var userId = authenticationTicket.UserId;

        var snapshot = new SessionSnapshot()
        {
            Id = authenticationId.ToString(),
            ExpiresUtc = expiresUtc,
            UserId = userId
        };
        
        await sessionRepository.SaveAsync(snapshot);
        
        AuthenticationId = authenticationId;
        ExpiresUtc = expiresUtc;
        _userId = userId;
        IsActive = true;
    }
    
    private DateTime ExpireTime => DateTime.UtcNow + _lifeTime;
}