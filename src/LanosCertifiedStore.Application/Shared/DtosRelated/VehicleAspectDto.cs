using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Application.Shared.DtosRelated;

public abstract record VehicleAspectDto : IIdentifiable<Guid>
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
}