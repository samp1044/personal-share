using FileShare.Main.Shared;
using Microsoft.AspNetCore.Identity;

namespace FileShare.Main.Authentication.AspNetIdentityAuthenticationProvider;

public class AspNetIdentityAuthenticationProvider(UserManager<UserIdentity> userManager): IAuthenticationProvider
{
    public async Task<Result<AuthenticationTicket>> AuthenticateAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!await userManager.CheckPasswordAsync(user, password))
        {
            throw new Exception("Password doesn't match");
        }
        
        return new Result<AuthenticationTicket>();
    }
}