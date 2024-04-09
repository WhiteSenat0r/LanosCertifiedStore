using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleBodyTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBodyType>,
    IVehicleBodyTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleBodyTypeSelectionProfile SelectionProfile { get; } = VehicleBodyTypeSelectionProfile.Default;
}