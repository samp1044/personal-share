using FileShare.Main.Authentication.Commands;
using FileShare.Main.Shared;
using FileShare.Main.Shared.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileShare.Main.Authentication.WebApi;

[ApiController]
[Route("v1/authentication")]
public class AuthenticationController(ICommandHandler<AuthenticateCommand> authenticate) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<BadInputResultDto>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAuthenticationAsync([FromBody] UserPasswordDto userPasswordDto)
    {
        await authenticate.HandleAsync(new AuthenticateCommand(userPasswordDto.Email, userPasswordDto.Password));
        
        return Created();
    }
}