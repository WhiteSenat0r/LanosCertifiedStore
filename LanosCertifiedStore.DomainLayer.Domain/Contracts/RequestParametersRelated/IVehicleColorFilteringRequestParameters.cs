using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleColorFilteringRequestParameters : IFilteringRequestParameters<VehicleColor>
{
    string? Name { get; set; }
    VehicleColorSelectionProfile SelectionProfile { get; }
}