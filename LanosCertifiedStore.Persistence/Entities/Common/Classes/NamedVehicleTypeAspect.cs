using Persistence.Entities.VehicleRelated;

namespace Persistence.Entities.Common.Classes;

internal abstract class NamedVehicleTypeAspect : NamedVehicleAspect
{
    public ICollection<VehicleModelEntity> Models { get; set; } = [];
    public ICollection<VehicleEntity> Vehicles { get; set; } = [];

    protected NamedVehicleTypeAspect() { }

    protected NamedVehicleTypeAspect(string name) : base(name) { }
}