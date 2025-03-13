using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalShare.Authentication;
using Xunit;

namespace PersonalShare.Test.Authentication;

public class AuthenticationControllerTest
{
    [Fact]
    public async Task Test_SuccessfulLoginReturns201Async()
    {
        var serviceMock = new Mock<IAuthenticationService>();
        var controller = new AuthenticationController(serviceMock.Object);
        var loginDto = new LoginDto("test@mail.com", "password");
        var successfulToken = new AuthenticationToken();

        var result = await controller.LoginAsync(loginDto);
        var createdResult = result as CreatedResult;
        
        Assert.NotNull(createdResult);
        Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
    }

    public async Task Test_WrongLoginReturns401Async()
    {
        var serviceMock = new Mock<IAuthenticationService>();
        var controller = new AuthenticationController(serviceMock.Object);
        var loginDto = new LoginDto("test@mail.com", "password");
        var successfulToken = new AuthenticationToken();

        Assert.ThrowsAsync<UnauthenticatedException>(() => controller.LoginAsync(loginDto));
    }
}