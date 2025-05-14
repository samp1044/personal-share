using FileShare.Main.Authentication.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileShare.Main.Authentication.WebApi;

[ApiController]
[Route("v1/authentication")]
public class AuthenticationController(
    IAuthenticationService authenticationService
) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAuthenticationAsync([FromBody] UserPasswordDto userPasswordDto)
    {
        await authenticationService.AuthenticateAsync(userPasswordDto.Email, userPasswordDto.Password);
        
        return Created();
    }
}