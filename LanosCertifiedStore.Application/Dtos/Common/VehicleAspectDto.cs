namespace Application.Dtos.Common;

public abstract record VehicleAspectDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
}