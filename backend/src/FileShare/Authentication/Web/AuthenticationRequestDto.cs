using FileShare.Main.Authentication.Application;

namespace FileShare.Main.Authentication.Web;

public class AuthDataDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }

    public CreateAuthenticationCommand AsCreateAuthenticationCommand()
    {
        return new CreateAuthenticationCommand(Email, Password);
    }
}