using PersonalShare.Features.Authentication.Service;

namespace PersonalShare.Features.Authentication;

public interface IAuthenticationService
{
    /// <summary>
    /// Authenticates a user given a email/password combination.
    /// </summary>
    /// <param name="email">The valid email of the user to authenticate</param>
    /// <param name="password">The valid password of the user to authenticate</param>
    /// <returns>The authentication result containing a session-token on success</returns>
    /// <exception cref="WrongCredentialsException">If the provided credentials to not match to any user</exception>
    /// <exception cref="BadEmailFormatException">If the provided email is of an invalid format</exception>
    Task<AuthenticationResult> AuthenticateAsync(string email, string password);
    
    /// <summary>
    /// Authenticates a user given a token.
    /// </summary>
    /// <param name="token">The valid token to authenticate</param>
    /// <returns>The authentication result containing a session-token on success</returns>
    /// <exception cref="WrongCredentialsException">If the provided token is invalid</exception>
    Task<AuthenticationResult> AuthenticateAsync(string token);
}