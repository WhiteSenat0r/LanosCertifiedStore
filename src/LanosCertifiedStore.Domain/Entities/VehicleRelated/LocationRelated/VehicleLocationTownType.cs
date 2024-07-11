using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTownType : NamedVehicleAspect
{
    public ICollection<VehicleLocationTown> Towns { get; init; } = [];
    
    public VehicleLocationTownType() { }

    public VehicleLocationTownType(string name) : base(name) { }
}