using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.LocationRelated;

public sealed class VehicleLocationTown : NamedVehicleAspect
{
    public VehicleLocationRegion LocationRegion { get; init; } = null!;
    
    public VehicleLocationTown() { }

    public VehicleLocationTown(string name) : base(name) { }

    public VehicleLocationTown(string name, VehicleLocationRegion locationRegion) : base(name) => 
        LocationRegion = locationRegion;
}