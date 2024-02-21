using Domain.Contracts.Common;

namespace Application.Dtos.IdentityDtos.AuthenticationDtos;

public sealed record UserDto : IEntity<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}