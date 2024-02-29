using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Application.RequestParams;

public sealed class VehicleImageFilteringRequestParameters : BaseFilteringRequestParameters<VehicleImage>,
    IVehicleImageFilteringRequestParameters
{
    public Guid? RelatedVehicleId { get; set; }
    public VehicleImageSelectionProfile SelectionProfile { get; } = VehicleImageSelectionProfile.Default;
}