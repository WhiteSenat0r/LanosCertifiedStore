using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Persistence.DataModels.VehicleRelated.LocationRelated;

public sealed class VehicleLocationRegionDataModel : NamedVehicleAspect
{
    public ICollection<VehicleLocationTownDataModel> RelatedTowns { get; init; } = [];
    
    public VehicleLocationRegionDataModel() { }

    public VehicleLocationRegionDataModel(string name) : base(name) { }
}