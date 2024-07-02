using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated;

namespace Application.RequestParameters;

public sealed class VehicleImageFilteringRequestParameters : BaseFilteringRequestParameters<VehicleImage>,
    IVehicleImageFilteringRequestParameters
{
    public Guid? RelatedVehicleId { get; set; }
    public VehicleImageSelectionProfile SelectionProfile => VehicleImageSelectionProfile.Default;
}