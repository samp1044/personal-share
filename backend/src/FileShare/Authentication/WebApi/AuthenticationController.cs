using FileShare.Main.Authentication.AuthenticationCommands;
using FileShare.Main.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileShare.Main.Authentication.WebApi;

[ApiController]
[Route("v1/authentication")]
public class AuthenticationController(ICommandHandler<AuthenticateCommand> authenticate) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAuthenticationAsync([FromBody] UserPasswordDto userPasswordDto)
    {
        await authenticate.HandleAsync(new AuthenticateCommand(userPasswordDto.Email, userPasswordDto.Password));
        
        return Created();
    }
}