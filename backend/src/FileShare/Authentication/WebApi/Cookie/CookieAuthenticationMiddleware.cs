using System.Security.Claims;
using FileShare.Main.Authentication.SessionManagement;
using Microsoft.AspNetCore.Authentication;

namespace FileShare.Main.Authentication.WebApi.Cookie;

internal class CookieAuthenticationMiddleware(RequestDelegate next) : AuthenticationMiddleware(next)
{
    private static string _cookieAuthScheme = "AuthenticationCookie";
    private readonly string _tokenIdentifier = "token";

    internal static void Setup(IServiceCollection services, CookieOptions cookieOptions)
    {
        _cookieAuthScheme = cookieOptions.Identifier;
        
        services.AddAuthentication(_cookieAuthScheme).AddCookie(options =>
        {
            options.SlidingExpiration = true;
            options.Cookie.Name = _cookieAuthScheme;
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });
    }
    
    protected override async Task<AuthenticationId?> LoadAuthenticationFromAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated != true)
        {
            return null;
        }
        
        var authResult = await context.AuthenticateAsync(_cookieAuthScheme);

        if (!authResult.Succeeded)
        {
            return null;
        }

        var token = authResult.Principal?.Claims.ToList().FirstOrDefault(c => c.Type == _tokenIdentifier);

        if (token == null)
        {
            return null;
        }

        return AuthenticationId.Parse(token.Value);
    }

    protected override async Task UpdateAuthenticationAsync(HttpContext context, ISession session)
    {
        if (session.IsActive)
        {
            var claims = new List<Claim>
            {
                new Claim(_tokenIdentifier, session.AuthenticationId.ToString())
            };

            var identity = new ClaimsIdentity(claims, _cookieAuthScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = session.ExpiresUtc,
            };
        
            await context.SignInAsync(_cookieAuthScheme, new ClaimsPrincipal(identity), authProperties);    
        }
        else
        {
            await context.SignOutAsync(_cookieAuthScheme);
        }
    }
}