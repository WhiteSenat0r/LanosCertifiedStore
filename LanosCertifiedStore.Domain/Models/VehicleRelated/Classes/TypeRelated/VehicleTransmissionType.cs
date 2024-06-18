using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Domain.Models.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleTransmissionType : NamedVehicleTypeAspect
{
    public VehicleTransmissionType() { }
    
    public VehicleTransmissionType(string name) : base(name) { }
}
