using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.Common.Classes;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleTransmissionTypeFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleTransmissionType>,
    IVehicleTransmissionTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleTransmissionTypeSelectionProfile SelectionProfile => VehicleTransmissionTypeSelectionProfile.Default;
}