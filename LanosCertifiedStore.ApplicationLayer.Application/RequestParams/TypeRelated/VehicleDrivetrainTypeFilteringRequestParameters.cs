using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.Common.Classes;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleDrivetrainTypeFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleDrivetrainType>, IVehicleDrivetrainTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleDrivetrainTypeSelectionProfile SelectionProfile => VehicleDrivetrainTypeSelectionProfile.Default;
}