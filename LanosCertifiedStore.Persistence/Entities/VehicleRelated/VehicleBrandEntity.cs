using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated;

internal sealed class VehicleBrandEntity : NamedVehicleAspect
{
    public ICollection<VehicleModelEntity> Models { get; set; } = [];
    public ICollection<VehicleEntity> Vehicles { get; set; } = [];
    
    public VehicleBrandEntity() { }

    public VehicleBrandEntity(string name) : base(name) { }
}
