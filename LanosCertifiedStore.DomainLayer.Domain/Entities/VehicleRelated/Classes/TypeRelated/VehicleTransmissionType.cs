using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleTransmissionType : NamedVehicleTypeAspect
{
    public VehicleTransmissionType() { }
    
    public VehicleTransmissionType(string name) : base(name) { }
}
