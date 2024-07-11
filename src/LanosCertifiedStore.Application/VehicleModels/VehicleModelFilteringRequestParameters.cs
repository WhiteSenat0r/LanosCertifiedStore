using Application.Shared.RequestParamsRelated;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleModels;

public sealed class VehicleModelFilteringRequestParameters : BaseFilteringRequestParameters<VehicleModel>,
    IVehicleModelFilteringRequestParameters
{
    public Guid? VehicleBrandId { get; init; }
}