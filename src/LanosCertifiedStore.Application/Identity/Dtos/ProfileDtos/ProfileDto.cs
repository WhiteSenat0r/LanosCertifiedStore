namespace Application.Identity.Dtos.ProfileDtos;

public sealed record ProfileDto
{
    public Guid Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}
