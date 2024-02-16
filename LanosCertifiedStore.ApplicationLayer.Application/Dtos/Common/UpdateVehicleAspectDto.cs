namespace Application.Dtos.Common;

public abstract record UpdateVehicleAspectDto
{
    public Guid Id { get; init; }
    public string UpdatedName { get; init; } = null!;
}