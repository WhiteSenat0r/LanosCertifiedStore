using Domain.Contracts.Common;

namespace Domain.Entities.Common.Classes;

public abstract class NamedVehicleAspect : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;

    protected NamedVehicleAspect() { }
    protected NamedVehicleAspect(string name) => Name = name;
}