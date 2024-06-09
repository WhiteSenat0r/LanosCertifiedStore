using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Domain.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleTransmissionTypeFilteringRequestParameters :
    IFilteringRequestParameters<VehicleTransmissionType>
{
    string? Name { get; set; }
    VehicleTransmissionTypeSelectionProfile SelectionProfile { get; }
}