namespace PersonalShare.Features.Authentication.Service;

public class AuthenticationResult
{
    public bool Succeeded { get; }
    public string? Token { get; }

    private AuthenticationResult(string token)
    {
        Token = token;
        Succeeded = true;
    }

    public static AuthenticationResult Success(string token)
    {
        return new AuthenticationResult(token);
    }
}