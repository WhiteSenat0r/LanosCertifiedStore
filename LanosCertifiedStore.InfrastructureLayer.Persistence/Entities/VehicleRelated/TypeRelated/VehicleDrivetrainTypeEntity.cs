using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated.TypeRelated;

internal sealed class VehicleDrivetrainTypeEntity : NamedVehicleTypeAspect
{
    public VehicleDrivetrainTypeEntity() { }

    public VehicleDrivetrainTypeEntity(string name) : base(name) { }
}