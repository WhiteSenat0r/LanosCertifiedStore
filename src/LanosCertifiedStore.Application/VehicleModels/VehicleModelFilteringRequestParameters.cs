using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleModels;

public sealed class VehicleModelFilteringRequestParameters : BaseFilteringRequestParameters<VehicleModel>,
    IVehicleModelFilteringRequestParameters
{
    public Guid? VehicleBrandId { get; init; }
}