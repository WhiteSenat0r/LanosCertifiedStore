using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Persistence.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTownEntity : NamedVehicleAspect
{
    public Guid LocationAreaId { get; set; }
    public VehicleLocationAreaEntity LocationArea { get; set; } = null!;
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegionEntity LocationRegion { get; set; } = null!;
    
    public VehicleLocationTownEntity() { }

    public VehicleLocationTownEntity(string name) : base(name) { }

    public VehicleLocationTownEntity(
        string name,
        VehicleLocationAreaEntity locationArea,
        VehicleLocationRegionEntity locationRegion) : base(name)
    {
        LocationArea = locationArea;
        LocationRegion = locationRegion;
    }
}