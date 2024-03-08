using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypesRelated;

public sealed class VehicleTransmissionType : NamedVehicleTypeAspect
{
    public VehicleTransmissionType() { }
    
    public VehicleTransmissionType(string name) : base(name) { }
}
