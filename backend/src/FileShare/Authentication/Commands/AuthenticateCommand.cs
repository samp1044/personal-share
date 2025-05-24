using FileShare.Main.Shared;

namespace FileShare.Main.Authentication.Commands;

public record AuthenticateCommand(string Username, string Password);

public class AuthenticateCommandHandler(IAuthenticationProvider authenticationProvider, ISession session)
    : ICommandHandler<AuthenticateCommand>
{
    public async Task HandleAsync(AuthenticateCommand command)
    {
        var result = await authenticationProvider.AuthenticateAsync(command.Username, command.Password);

        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException();
        }

        var authentication = result.Get();
        await session.CreateAsync(authentication);
    }
}

