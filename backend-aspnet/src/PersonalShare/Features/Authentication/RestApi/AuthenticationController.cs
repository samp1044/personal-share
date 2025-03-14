using Microsoft.AspNetCore.Mvc;

namespace PersonalShare.Features.Authentication.RestApi;

[ApiController]
[Route("api/v1/authentication")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}