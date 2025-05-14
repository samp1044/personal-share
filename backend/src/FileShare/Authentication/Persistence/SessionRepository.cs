using FileShare.Main.Authentication.SessionManagement;

namespace FileShare.Main.Authentication.Persistence;

public class SessionRepository: ISessionRepository
{
    public Task<SessionSnapshot?> LoadAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(SessionSnapshot snapshot)
    {
        throw new NotImplementedException();
    }
}