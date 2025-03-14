using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalShare.Common.Application;
using PersonalShare.Features.Authentication;
using PersonalShare.Features.Authentication.RestApi;
using PersonalShare.Features.Authentication.Service;
using Xunit;

namespace PersonalShare.Test.Authentication;

public class AuthenticationControllerTest
{
    private readonly Mock<IAuthenticationService> _mockedAuthenticationService;
    private readonly AuthenticationController _authenticationController;
    private readonly LoginDto _defaultLoginDto;
    
    public AuthenticationControllerTest()
    {
        _mockedAuthenticationService = new Mock<IAuthenticationService>();
        _authenticationController = new AuthenticationController(_mockedAuthenticationService.Object);
        _defaultLoginDto = new LoginDto("test@mail.com", "password");
    }
    
    [Fact]
    public async Task Test_SuccessfulLoginReturns201Async()
    {
        var expectedResult = AuthenticationResult.Success("token");
        _mockedAuthenticationService.Setup(s => 
                s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(expectedResult);
        
        var result = await _authenticationController.LoginAsync(_defaultLoginDto);
        var createdResult = result as CreatedResult;
        
        Assert.NotNull(createdResult);
        Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
    }
    
    [Fact]
    public async Task Test_FailedLoginThrowsUnauthenticatedExceptionAsync()
    {
        _mockedAuthenticationService.Setup(s =>
            s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new WrongCredentialsException());
        await Assert.ThrowsAsync<UnauthenticatedException>(() => _authenticationController.LoginAsync(_defaultLoginDto));
    }

    [Fact]
    public async Task Test_WrongLoginDataThrowsValidationExceptionAsync()
    {
        _mockedAuthenticationService.Setup(s =>
            s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new BadEmailFormatException());
        await Assert.ThrowsAsync<ValidationException>(() => _authenticationController.LoginAsync(_defaultLoginDto));
    }
}