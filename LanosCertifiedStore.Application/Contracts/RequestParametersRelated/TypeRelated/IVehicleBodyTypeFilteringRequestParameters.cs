using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleBodyTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleBodyType>
{
    string? Name { get; }
    VehicleBodyTypeSelectionProfile SelectionProfile { get; }
}