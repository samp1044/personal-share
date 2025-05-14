namespace FileShare.Main.Authentication.WebApi;

internal abstract class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext, ISession session)
    {
        var authentication = await LoadAuthenticationFromAsync(httpContext);

        try
        {
            if (authentication != null)
            {
                await session.LoadAsync(authentication);
            }

            await next(httpContext);
        }
        finally
        {
            await UpdateAuthenticationAsync(httpContext, session);    
        }
    }
    
    /// <summary>
    /// Retrieves the authentication info attached to the incoming request if any
    /// </summary>
    /// <param name="context">The context of the incoming request</param>
    /// <returns>The authentication info attached to the request. Null if none</returns>
    protected abstract Task<AuthenticationInfo?> LoadAuthenticationFromAsync(HttpContext context);
    
    /// <summary>
    /// Updates the authentication info attached to the response based on the current state of the session
    /// </summary>
    /// <param name="context">The context of the outgoing response</param>
    /// <param name="session">The current session</param>
    /// <returns></returns>
    protected abstract Task UpdateAuthenticationAsync(HttpContext context, ISession session);
}