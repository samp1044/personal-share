namespace UserManagement.RestApi;

public record EmailPasswordAuthenticationDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}