using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated.TypeRelated;

internal sealed class VehicleTransmissionTypeEntity : NamedVehicleTypeAspect
{
    public VehicleTransmissionTypeEntity() { }

    public VehicleTransmissionTypeEntity(string name) : base(name) { }
}