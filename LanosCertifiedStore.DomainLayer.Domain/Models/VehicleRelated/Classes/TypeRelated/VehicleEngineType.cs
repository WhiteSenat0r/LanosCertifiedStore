using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Domain.Models.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleEngineType : NamedVehicleTypeAspect
{
    public VehicleEngineType() { }
    
    public VehicleEngineType(string name) : base(name) { }
}
