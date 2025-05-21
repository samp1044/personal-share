namespace FileShare.Main.Authentication.SessionManagement;

public interface ISessionRepository
{
    public Task<SessionSnapshot?> LoadAsync(AuthenticationId id);
    public Task SaveAsync(SessionSnapshot snapshot);

    public Task RemoveAllExpiredAsync();
}