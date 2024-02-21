namespace Application.Dtos.IdentityDtos.AuthenticationDtos;

public sealed record UserDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}