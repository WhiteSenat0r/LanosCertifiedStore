using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;

namespace Application.Contracts.RequestParametersRelated.LocationRelated;

public interface IVehicleLocationAreaFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationArea>
{
    string? Name { get; set; }
    VehicleLocationAreaSelectionProfile SelectionProfile { get; }
}