using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleDrivetrainType : NamedVehicleTypeAspect
{
    public VehicleDrivetrainType() { }

    public VehicleDrivetrainType(string name) : base(name) { }
}