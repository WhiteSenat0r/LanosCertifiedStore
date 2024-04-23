using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;

namespace Domain.Contracts.RequestParametersRelated.LocationRelated;

public interface IVehicleLocationTownFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationTown>
{
    string? Name { get; set; }
    VehicleLocationTownSelectionProfile SelectionProfile { get; }
}