using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.LocationRelated;

public sealed class VehicleLocationRegion : NamedVehicleAspect
{
    public ICollection<VehicleLocationTown> RelatedTowns { get; init; } = [];
    public ICollection<VehicleLocationArea> RelatedAreas { get; init; } = [];
    
    public VehicleLocationRegion() { }

    public VehicleLocationRegion(string name) : base(name) { }
}