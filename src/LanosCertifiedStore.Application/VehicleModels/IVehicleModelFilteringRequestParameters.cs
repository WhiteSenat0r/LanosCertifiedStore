using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleModels;

public interface IVehicleModelFilteringRequestParameters : IFilteringRequestParameters<VehicleModel>
{
    Guid? VehicleBrandId { get; }
}