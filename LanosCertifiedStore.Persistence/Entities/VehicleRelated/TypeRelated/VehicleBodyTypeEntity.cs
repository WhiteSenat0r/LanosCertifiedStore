using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated.TypeRelated;

internal sealed class VehicleBodyTypeEntity : NamedVehicleTypeAspect
{
    public VehicleBodyTypeEntity() { }

    public VehicleBodyTypeEntity(string name) : base(name) { }
}