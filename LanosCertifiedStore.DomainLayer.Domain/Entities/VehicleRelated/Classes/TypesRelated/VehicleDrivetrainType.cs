using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypesRelated;

public sealed class VehicleDrivetrainType : NamedVehicleTypeAspect
{
    public VehicleDrivetrainType() { }
    
    public VehicleDrivetrainType(string name) : base(name) { }
}
