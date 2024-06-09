using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;

namespace Domain.Contracts.RequestParametersRelated.LocationRelated;

public interface IVehicleLocationRegionFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationRegion>
{
    string? Name { get; set; }
    VehicleLocationRegionSelectionProfile SelectionProfile { get; }
}