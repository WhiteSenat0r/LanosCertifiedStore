using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleModelFilteringRequestParameters : IFilteringRequestParameters<VehicleModel>
{
    string? Name { get; set; }
    string? ContainedBrandName { get; set; }
    VehicleModelSelectionProfile SelectionProfile { get; set; }
}