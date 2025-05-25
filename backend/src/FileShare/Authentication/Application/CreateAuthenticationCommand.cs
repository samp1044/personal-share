namespace FileShare.Main.Authentication.Application;

public class CreateAuthenticationCommand(string email, string password)
{
    public string Email { get; } = email;
    public string Password { get; } = password;
}