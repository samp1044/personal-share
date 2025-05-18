using Microsoft.AspNetCore.Identity;

namespace FileShare.Main.Authentication.AspNetIdentityAuthenticationProvider;

internal static class Setup
{
    internal static void SetupAspNetIdentityAuthenticationProvider(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        });
    }
}