using Microsoft.AspNetCore.Authentication;

namespace FileShare.Main.Authentication.Web.Cookie;

public abstract class AuthenticationCookie
{
    private static string _identifier = "AuthenticationCookie";
    
    public static void Setup(IServiceCollection services, CookieOptions options)
    {
        _identifier = options.Identifier;
        
        services.AddAuthentication(_identifier).AddCookie(options =>
        {
            options.SlidingExpiration = true;
            options.Cookie.Name = _identifier;
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });
    }

    public static async Task<AuthenticationCookie> FromAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated != true)
        {
            return new NoCookie();
        }
        
        var authResult = await context.AuthenticateAsync(_identifier);

        if (!authResult.Succeeded)
        {
            await context.SignOutAsync(_identifier);
            return new NoCookie();
        }
        
        authResult.Properties.Principal.
    }

    public bool IsAuthenticated => false;
    public IAuthenticationToken Token => throw new ApplicationException();
    
    public abstract void UpdateWith(ISession session);
    public abstract void Expire();
}

class Cookie : AuthenticationCookie
{
    public override void UpdateWith(ISession session)
    {
        throw new NotImplementedException();
    }

    public override void Expire()
    {
        throw new NotImplementedException();
    }
}

class NoCookie : AuthenticationCookie
{
    internal NoCookie() { }
    public override void UpdateWith(ISession session)
    {
        throw new ApplicationException("No cookie has been found");
    }

    public override void Expire()
    {
        throw new ApplicationException("No cookie has been found");
    }
}