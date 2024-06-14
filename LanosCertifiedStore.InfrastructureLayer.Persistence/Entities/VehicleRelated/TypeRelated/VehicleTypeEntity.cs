using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated.TypeRelated;

internal sealed class VehicleTypeEntity : NamedVehicleTypeAspect
{
    public VehicleTypeEntity() { }

    public VehicleTypeEntity(string name) : base(name) { }
}