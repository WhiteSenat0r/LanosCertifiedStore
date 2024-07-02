using Domain.Contracts.Common;

namespace Application.Dtos.Common;

public abstract record VehicleAspectDto : IIdentifiable<Guid>
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
}