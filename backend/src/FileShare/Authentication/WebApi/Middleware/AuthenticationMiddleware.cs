using FileShare.Main.Authentication.Commands;
using FileShare.Main.Shared;
using Microsoft.AspNetCore.Authentication;

namespace FileShare.Main.Authentication.WebApi.Middleware;

internal class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext, ICommandHandler<AuthenticateCommand> authenticate, AuthOptions authOptions)
    {
        await LoadAuthenticationTokenIfExitsAsync(httpContext, authenticate, authOptions);
        
        await next(httpContext);

        await RemoveAuthenticationTokenIfNotAuthenticatedAsync(httpContext);
    }

    private async Task LoadAuthenticationTokenIfExitsAsync(HttpContext context, ICommandHandler<AuthenticateCommand> authenticate, AuthOptions authOptions)
    {
        var result = await context.AuthenticateAsync();

        if (result.Succeeded)
        {
            var claims = result.Principal?.Claims.ToList();
            var token = claims?.FirstOrDefault(claim => claim.Type == authOptions.AuthTokenName)?.Value;

            if (token != null)
            {
                await authenticate.HandleAsync(new AuthenticateCommand(token));
            }
        }
    }

    private async Task RemoveAuthenticationTokenIfNotAuthenticatedAsync(HttpContext context)
    {
        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            await context.SignOutAsync();
        }
    }
}