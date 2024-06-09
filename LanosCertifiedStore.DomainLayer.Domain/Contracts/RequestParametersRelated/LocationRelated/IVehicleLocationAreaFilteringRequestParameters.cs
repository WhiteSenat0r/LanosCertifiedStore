using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;

namespace Domain.Contracts.RequestParametersRelated.LocationRelated;

public interface IVehicleLocationAreaFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationArea>
{
    string? Name { get; set; }
    VehicleLocationAreaSelectionProfile SelectionProfile { get; }
}