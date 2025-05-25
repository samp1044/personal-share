using System.Security.Claims;
using FileShare.Main.Authentication.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileShare.Main.Authentication.Web;

[Route("api/v1/authentication")]
[ApiController]
public class AuthenticationController(ICommandHandler<CreateAuthenticationCommand, SessionInfo> authenticationHandler, AuthWebApiOptions authWebApiOptions): ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAuthenticationAsync([FromBody] AuthDataDto authData)
    {
        var authenticationCommand = authData.AsCreateAuthenticationCommand();
        var sessionInfo = await authenticationHandler.HandleAsync(authenticationCommand);

        var claims = new List<Claim>() { new Claim(authWebApiOptions.AuthToken, sessionInfo.AuthToken) }; 
        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties()
        {
            ExpiresUtc = sessionInfo.ExpiresUtc
        };
        
        await HttpContext.SignInAsync(principal, properties);
        
        return new CreatedResult("", sessionInfo.AuthToken);
    }
}