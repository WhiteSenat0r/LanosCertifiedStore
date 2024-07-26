using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleTransmissionType : NamedVehicleTypeAspect
{
    public VehicleTransmissionType() { }

    public VehicleTransmissionType(string name) : base(name) { }
}