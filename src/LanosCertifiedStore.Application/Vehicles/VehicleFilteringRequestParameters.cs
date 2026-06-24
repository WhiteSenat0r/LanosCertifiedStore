using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public sealed class VehicleFilteringRequestParameters : BaseFilteringRequestParameters<Vehicle>,
    IVehicleFilteringRequestParameters
{
    public List<Guid>? BrandIds { get; set; }
    public List<Guid>? ModelIds { get; set; }
    public List<Guid>? VehicleTypeIds { get; set; }
    public List<Guid>? ColorIds { get; set; }
    public List<Guid>? BodyTypeIds { get; set; }
    public List<Guid>? EngineTypeIds { get; set; }
    public List<Guid>? TransmissionTypeIds { get; set; }
    public List<Guid>? DrivetrainTypeIds { get; set; }
    public List<Guid>? LocationTownIds { get; set; }
    public List<Guid>? LocationAreaIds { get; set; }
    public List<Guid>? LocationRegionIds { get; set; }
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
}