using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Persistence.DataModels.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTownDataModel : NamedVehicleAspect
{
    public Guid LocationAreaId { get; set; }
    public VehicleLocationAreaDataModel LocationArea { get; set; } = null!;
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegionDataModel LocationRegion { get; set; } = null!;
    
    public VehicleLocationTownDataModel() { }

    public VehicleLocationTownDataModel(string name) : base(name) { }

    public VehicleLocationTownDataModel(
        string name,
        VehicleLocationAreaDataModel locationArea,
        VehicleLocationRegionDataModel locationRegion) : base(name)
    {
        LocationArea = locationArea;
        LocationRegion = locationRegion;
    }
}