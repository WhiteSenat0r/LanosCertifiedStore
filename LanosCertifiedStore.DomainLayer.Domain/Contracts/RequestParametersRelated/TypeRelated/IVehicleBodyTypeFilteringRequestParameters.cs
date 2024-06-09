using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Domain.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleBodyTypeFilteringRequestParameters : IFilteringRequestParameters<VehicleBodyType>
{
    string? Name { get; set; }
    VehicleBodyTypeSelectionProfile SelectionProfile { get; }
}