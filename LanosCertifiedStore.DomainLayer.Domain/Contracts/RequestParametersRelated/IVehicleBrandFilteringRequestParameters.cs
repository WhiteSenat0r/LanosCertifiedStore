using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleBrandFilteringRequestParameters : IFilteringRequestParameters<VehicleBrand>
{
    string? Name { get; set; }
    string? ContainedModelName { get; set; }
    VehicleBrandSelectionProfile SelectionProfile { get; set; }
}