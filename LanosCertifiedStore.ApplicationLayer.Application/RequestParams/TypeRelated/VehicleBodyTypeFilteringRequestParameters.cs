using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.Common.Classes;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleBodyTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBodyType>,
    IVehicleBodyTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleBodyTypeSelectionProfile SelectionProfile => VehicleBodyTypeSelectionProfile.Default;
}