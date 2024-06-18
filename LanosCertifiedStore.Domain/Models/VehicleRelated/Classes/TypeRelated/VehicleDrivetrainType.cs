using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Domain.Models.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleDrivetrainType : NamedVehicleTypeAspect
{
    public VehicleDrivetrainType() { }
    
    public VehicleDrivetrainType(string name) : base(name) { }
}
