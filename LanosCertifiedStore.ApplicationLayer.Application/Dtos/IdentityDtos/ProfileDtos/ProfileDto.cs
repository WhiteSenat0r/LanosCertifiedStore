using Domain.Contracts.Common;

namespace Application.Dtos.IdentityDtos.ProfileDtos;

public sealed record ProfileDto : IIdentifiable<Guid>
{
    public Guid Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}
