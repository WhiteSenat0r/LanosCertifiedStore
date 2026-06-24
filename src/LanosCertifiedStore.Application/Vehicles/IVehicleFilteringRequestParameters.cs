using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public interface IVehicleFilteringRequestParameters : IFilteringRequestParameters<Vehicle>
{
    List<Guid>? BrandIds { get; set; }
    List<Guid>? ModelIds { get; set; }
    List<Guid>? VehicleTypeIds { get; set; }
    List<Guid>? ColorIds { get; set; }
    List<Guid>? BodyTypeIds { get; set; }
    List<Guid>? EngineTypeIds { get; set; }
    List<Guid>? TransmissionTypeIds { get; set; }
    List<Guid>? DrivetrainTypeIds { get; set; }
    List<Guid>? LocationTownIds { get; set; }
    List<Guid>? LocationAreaIds { get; set; }
    List<Guid>? LocationRegionIds { get; set; }
    decimal? LowerPriceLimit { get; set; }
    decimal? UpperPriceLimit { get; set; }
}