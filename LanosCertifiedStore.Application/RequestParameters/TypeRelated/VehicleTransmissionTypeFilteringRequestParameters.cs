using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.RequestParameters.TypeRelated;

public sealed class VehicleTransmissionTypeFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleTransmissionType>,
    IVehicleTransmissionTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleTransmissionTypeSelectionProfile SelectionProfile => VehicleTransmissionTypeSelectionProfile.Default;
}