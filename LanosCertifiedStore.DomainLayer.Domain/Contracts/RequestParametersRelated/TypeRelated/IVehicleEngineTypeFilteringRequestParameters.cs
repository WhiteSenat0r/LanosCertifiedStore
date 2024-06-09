using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Domain.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleEngineTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleEngineType>
{
    string? Name { get; set; }
    VehicleEngineTypeSelectionProfile SelectionProfile { get; }
}