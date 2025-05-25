using FileShare.Main.Authentication.Web;

namespace FileShare.Main.Authentication.Application;

public class CreateAuthenticationSessionCommandHandler: ICommandHandler<CreateAuthenticationCommand, SessionInfo>
{
    public async Task<SessionInfo> HandleAsync(CreateAuthenticationCommand command)
    {
        if (command.Email != "testuser")
        {
            throw InvalidCredentialsException();
        }
        
        if (command.Password != "test")
        {
            throw InvalidCredentialsException();
        }
        
        return new SessionInfo()
        {
            AuthToken = Guid.NewGuid().ToString(),
            ExpiresUtc = DateTime.UtcNow.AddHours(1),
        };
    }
}