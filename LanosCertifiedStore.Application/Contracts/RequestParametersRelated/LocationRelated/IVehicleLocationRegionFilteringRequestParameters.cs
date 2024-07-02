using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.Contracts.RequestParametersRelated.LocationRelated;

public interface IVehicleLocationRegionFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationRegion>
{
    string? Name { get; set; }
    VehicleLocationRegionSelectionProfile SelectionProfile { get; }
}