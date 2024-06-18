using Domain.Contracts.Common;

namespace Domain.Models.VehicleRelated.Classes.Common.Classes;

public abstract class NamedVehicleAspect : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = null!;

    protected NamedVehicleAspect() { }
    protected NamedVehicleAspect(string name) => Name = name;
}