using System.Security.Claims;
using FileShare.Main.Authentication.SessionManagement;
using Microsoft.AspNetCore.Authentication;

namespace FileShare.Main.Authentication.WebApi.Cookie;

internal class CookieAuthenticationMiddleware(RequestDelegate next) : AuthenticationMiddleware(next)
{
    private static string _cookieAuthScheme = "AuthenticationCookie";
    private readonly string _authenticationTokenIdentifier = "token";

    internal static void Setup(IServiceCollection services, CookieOptions cookieOptions)
    {
        _cookieAuthScheme = cookieOptions.Identifier;
        
        services.AddAuthentication().AddCookie(_cookieAuthScheme, options =>
        {
            options.SlidingExpiration = true;
            options.Cookie.Name = _cookieAuthScheme;
            options.Cookie.HttpOnly = cookieOptions.HttpOnly;
            options.Cookie.SameSite = Enum.Parse<SameSiteMode>(cookieOptions.SameSite);
            options.Cookie.SecurePolicy = Enum.Parse<CookieSecurePolicy>(cookieOptions.SecurePolicy);
        });
    }

    internal static void Use(IApplicationBuilder app)
    {
        app.UseMiddleware<CookieAuthenticationMiddleware>();
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

        var authenticationToken = authResult.Principal?.Claims.ToList().FirstOrDefault(c => c.Type == _authenticationTokenIdentifier);

        if (authenticationToken == null)
        {
            return null;
        }

        return AuthenticationId.Parse(authenticationToken.Value);
    }

    protected override async Task UpdateAuthenticationAsync(HttpContext context, ISession session)
    {
        if (session.IsActive)
        {
            var claims = new List<Claim>
            {
                new Claim(_authenticationTokenIdentifier, session.AuthenticationId.ToString())
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