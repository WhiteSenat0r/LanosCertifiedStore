using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTown : NamedVehicleAspect
{
    public Guid LocationAreaId { get; set; }
    public VehicleLocationArea LocationArea { get; set; } = null!;
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegion LocationRegion { get; set; } = null!;
    public Guid LocationTownTypeId { get; set; }
    public VehicleLocationTownType LocationTownType { get; set; } = null!;
    
    public VehicleLocationTown() { }

    public VehicleLocationTown(string name) : base(name) { }

    public VehicleLocationTown(
        string name,
        VehicleLocationArea locationArea,
        VehicleLocationRegion locationRegion) : base(name)
    {
        LocationArea = locationArea;
        LocationRegion = locationRegion;
    }
}