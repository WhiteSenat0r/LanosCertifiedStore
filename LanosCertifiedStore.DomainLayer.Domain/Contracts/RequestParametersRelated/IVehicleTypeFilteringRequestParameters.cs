using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated;

namespace Domain.Contracts.RequestParametersRelated;

public interface IVehicleTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleType>
{
    string? Name { get; set; }
    VehicleTypeSelectionProfile SelectionProfile { get; }
}