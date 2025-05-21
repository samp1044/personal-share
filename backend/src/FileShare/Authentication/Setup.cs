using FileShare.Main.Authentication.AspNetIdentityAuthenticationProvider;
using FileShare.Main.Authentication.WebApi.Cookie;
using FileShare.Main.Shared.Persistence;
using Microsoft.AspNetCore.Identity;

namespace FileShare.Main.Authentication;

public static class Setup
{
    public static void SetupAuthentication(this IServiceCollection services, AuthenticationOptions options)
    {
        CookieAuthenticationMiddleware.Setup(services, options.CookieOptions);
        services.SetupAspNetIdentityAuthenticationProvider();
    }

    public static void UseAuthentication(this IApplicationBuilder app)
    {
        CookieAuthenticationMiddleware.Use(app);
    }

    private static void SetupAspNetIdentityAuthenticationProvider(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        });
        
        services.AddIdentityCore<UserIdentity>().AddEntityFrameworkStores<ApplicationDbContext>();
    }
}