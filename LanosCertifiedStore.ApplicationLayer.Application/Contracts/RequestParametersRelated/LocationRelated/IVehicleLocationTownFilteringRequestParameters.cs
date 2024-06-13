using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Domain.Models.VehicleRelated.Classes.LocationRelated;

namespace Application.Contracts.RequestParametersRelated.LocationRelated;

public interface IVehicleLocationTownFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationTown>
{
    string? Name { get; set; }
    VehicleLocationTownSelectionProfile SelectionProfile { get; }
}