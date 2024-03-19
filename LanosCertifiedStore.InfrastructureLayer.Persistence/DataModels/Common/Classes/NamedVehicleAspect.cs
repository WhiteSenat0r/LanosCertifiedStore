using Domain.Contracts.Common;

namespace Persistence.DataModels.Common.Classes;

internal abstract class NamedVehicleAspect : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;

    protected NamedVehicleAspect() { }
    protected NamedVehicleAspect(string name) => Name = name;
}