using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleTransmissionTypeFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleTransmissionType>, IVehicleTransmissionTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleTransmissionTypeSelectionProfile SelectionProfile { get; } =
        VehicleTransmissionTypeSelectionProfile.Default;
}