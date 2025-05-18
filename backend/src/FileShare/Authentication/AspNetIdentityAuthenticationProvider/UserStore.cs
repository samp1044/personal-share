using Microsoft.AspNetCore.Identity;

namespace FileShare.Main.Authentication.AspNetIdentityAuthenticationProvider;

public class UserStore: IUserStore<UserIdentity>
{
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public Task<string> GetUserIdAsync(UserIdentity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetUserNameAsync(UserIdentity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(UserIdentity user, string? userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedUserNameAsync(UserIdentity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(UserIdentity user, string? normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(UserIdentity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(UserIdentity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(UserIdentity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserIdentity?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserIdentity?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}