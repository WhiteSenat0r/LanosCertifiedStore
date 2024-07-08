using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleTransmissionType : NamedVehicleTypeAspect
{
    public VehicleTransmissionType() { }

    public VehicleTransmissionType(string name) : base(name) { }
}