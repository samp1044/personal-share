using FileShare.Main.Authentication.SessionManagement;
using Microsoft.EntityFrameworkCore;

namespace FileShare.Main.Authentication.Persistence;

public class SessionRepository: ISessionRepository
{
    private readonly DbContext _dbContext;

    public SessionRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SessionSnapshot?> LoadAsync(AuthenticationId id)
    {
        var rawId = id.ToString();
        var result = await _dbContext.Set<SessionSnapshot>()
            .SingleOrDefaultAsync(e => e.Id == rawId);

        return result;
    }

    public async Task SaveAsync(SessionSnapshot snapshot)
    {
        var existing = await _dbContext.Set<SessionSnapshot>()
            .SingleOrDefaultAsync(e => e.Id == snapshot.Id);

        if (existing == null)
        {
            _dbContext.Set<SessionSnapshot>().Add(snapshot);
        }
        else
        {
            var entry = _dbContext.Entry(existing);
            entry.CurrentValues.SetValues(snapshot);
        }
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAllExpiredAsync()
    {
        var now = DateTime.UtcNow;
        
        await _dbContext.Set<SessionSnapshot>()
            .Where(e => e.ExpiresUtc <= now)
            .ExecuteDeleteAsync();
    }
}