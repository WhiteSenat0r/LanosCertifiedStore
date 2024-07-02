using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleType>
{
    string? Name { get; set; }
    VehicleTypeSelectionProfile SelectionProfile { get; }
}