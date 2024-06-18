using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Domain.Models.VehicleRelated.Classes.LocationRelated;

public sealed class VehicleLocationArea : NamedVehicleAspect
{
    public ICollection<VehicleLocationTown> RelatedTowns { get; init; } = [];
    public VehicleLocationRegion LocationRegion { get; init; } = null!;
    
    public VehicleLocationArea() { }

    public VehicleLocationArea(string name, VehicleLocationRegion locationRegion) : base(name) => 
        LocationRegion = locationRegion;
}