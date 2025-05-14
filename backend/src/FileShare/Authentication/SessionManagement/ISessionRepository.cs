namespace FileShare.Main.Authentication.SessionManagement;

public interface ISessionRepository
{
    public Task<SessionSnapshot?> LoadAsync(string id);
    public Task SaveAsync(SessionSnapshot snapshot);
}