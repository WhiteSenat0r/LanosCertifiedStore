using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypesRelated;

public sealed class VehicleEngineType : NamedVehicleTypeAspect
{
    public VehicleEngineType() { }
    
    public VehicleEngineType(string name) : base(name) { }
}
