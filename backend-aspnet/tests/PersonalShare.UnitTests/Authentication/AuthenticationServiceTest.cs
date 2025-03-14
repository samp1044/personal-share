using PersonalShare.Features.Authentication.Service;
using Xunit;

namespace PersonalShare.Test.Authentication;

public class AuthenticationServiceTest
{
    private readonly AuthenticationSessionService _authenticationSessionService;

    public AuthenticationServiceTest()
    {
        _authenticationSessionService = new AuthenticationSessionService();
    }
    
    [Fact]
    public async Task Test_AuthenticateValidCredentialsReturnSessionTokenAsync()
    {
        var result = await _authenticationSessionService.AuthenticateAsync("some@email.com", "thepassword");
        
        Assert.True(result.Succeeded);
        Assert.NotNull(result.Token);
    }
    
    [Fact]
    public async Task Test_SessionTokenCanBeUsedToReauthenticateAsync()
    {
        var result = await _authenticationSessionService.AuthenticateAsync("some@email.com", "thepassword");
        Assert.NotNull(result.Token);

        var resultAfterToken = await _authenticationSessionService.AuthenticateAsync(result.Token);
        
        Assert.True(resultAfterToken.Succeeded);
        Assert.NotNull(result.Token);
    }
    
    [Fact]
    public async Task Test_InvalidEMailCausesWrongEmailFormatExceptionAsync()
    {
        await Assert.ThrowsAsync<BadEmailFormatException>(() =>
            _authenticationSessionService.AuthenticateAsync("noemail", "thepassword"));
    }
    
    [Fact]
    public async Task Test_WrongCredentialsCauseCredentialsExceptionAsync()
    {
        await Assert.ThrowsAsync<BadEmailFormatException>(() =>
            _authenticationSessionService.AuthenticateAsync("some@email.com", "wrongpassword"));
    }

    [Fact]
    public async Task Test_WrongTokenCausesCredentialsExceptionAsync()
    {
        await Assert.ThrowsAsync<BadEmailFormatException>(() =>
            _authenticationSessionService.AuthenticateAsync("token"));
    }
    
    // TODO: session can be accessed after successful authentication
}