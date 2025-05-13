using FileShare.Main.Authentication.Web.Cookie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileShare.Main.Authentication.Web;

[ApiController]
[Route("v1/authentication")]
public class AuthenticationController(
    IAuthenticator authenticator, 
    AuthenticationWebConfig config
) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAuthenticationAsync([FromBody] UserPasswordDto userPasswordDto)
    {
        var token = await authenticator.AuthenticateAsync(userPasswordDto.Email, userPasswordDto.Password);
        SupplyTokenAsHeader(token);
        
        return Created();
    }

    private void SupplyTokenAsHeader(IAuthenticationToken token)
    {
        Response.Headers[config.AuthenticationTokenHeader] = token.ToString();
    }
}