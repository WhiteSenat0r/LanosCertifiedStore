using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public interface IVehicleFilteringRequestParameters : IFilteringRequestParameters<Vehicle>
{
    Guid? BrandId { get; set; }
    Guid? ModelId { get; set; }
    Guid? TypeId { get; set; }
    Guid? EngineTypeId { get; set; }
    Guid? DrivetrainTypeId { get; set; }
    Guid? TransmissionTypeId { get; set; }
    Guid? BodyTypeId { get; set; }
    Guid? ColorId { get; set; }
    Guid? LocationRegionAreaId { get; set; }
    Guid? LocationAreaId { get; set; }
    Guid? LocationTownId { get; set; }
    Guid? OwnerId { get; set; }
    decimal? LowerPriceLimit { get; set; }
    decimal? UpperPriceLimit { get; set; }
}