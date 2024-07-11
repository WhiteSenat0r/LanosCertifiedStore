using Application.Shared.RequestParamsRelated;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleModels;

public interface IVehicleModelFilteringRequestParameters : IFilteringRequestParameters<VehicleModel>
{
    Guid? VehicleBrandId { get; }
}