using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.RequestParameters.TypeRelated;

public sealed class VehicleDrivetrainTypeFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleDrivetrainType>,
    IVehicleDrivetrainTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleDrivetrainTypeSelectionProfile SelectionProfile => VehicleDrivetrainTypeSelectionProfile.Default;
}