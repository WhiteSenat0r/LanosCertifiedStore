using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.Contracts.RequestParametersRelated.TypeRelated;

public interface IVehicleTransmissionTypeFilteringRequestParameters :
    IFilteringRequestParameters<VehicleTransmissionType>
{
    string? Name { get; set; }
    VehicleTransmissionTypeSelectionProfile SelectionProfile { get; }
}