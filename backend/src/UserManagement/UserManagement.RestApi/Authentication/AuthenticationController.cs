using Microsoft.AspNetCore.Mvc;

namespace UserManagement.RestApi.Authentication;

[ApiController]
[Route("/v1/authentication")]
public class AuthenticationController: ControllerBase
{
    [HttpPost("")]
    public async Task CreateAuthenticationAsync([FromBody] EmailPasswordAuthenticationDto authenticationDto)
    {
        
    }
}