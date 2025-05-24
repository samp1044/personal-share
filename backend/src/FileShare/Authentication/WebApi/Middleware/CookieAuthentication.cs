using Microsoft.AspNetCore.Authentication;

namespace FileShare.Main.Authentication.WebApi.Middleware;

internal static class CookieAuthentication
{
    public static void ConfigureCookieAuthentication(this AuthenticationBuilder builder, CookieOptions cookieOptions)
    {
        builder.AddCookie(options =>
        {
            options.SlidingExpiration = true;
            options.Cookie.Name = cookieOptions.Name;
            options.Cookie.HttpOnly = cookieOptions.HttpOnly;
            options.Cookie.SameSite = Enum.Parse<SameSiteMode>(cookieOptions.SameSite);
            options.Cookie.SecurePolicy = Enum.Parse<CookieSecurePolicy>(cookieOptions.SecurePolicy);
        });
    } 
}