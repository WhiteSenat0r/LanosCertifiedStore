using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public class VehicleFilteringRequestParameters : BaseFilteringRequestParameters<Vehicle>,
    IVehicleFilteringRequestParameters
{
    public List<Guid> BrandIds { get; set; } = [];
    public List<Guid> ModelIds { get; set; } = [];
    public List<Guid> TypeIds { get; set; } = [];
    public List<Guid> EngineTypeIds { get; set; } = [];
    public List<Guid> DrivetrainTypeIds { get; set; } = [];
    public List<Guid> TransmissionTypeIds { get; set; } = [];
    public List<Guid> BodyTypeIds { get; set; } = [];
    public List<Guid> ColorIds { get; set; } = [];
    public Guid? LocationRegionAreaId { get; set; }
    public Guid? LocationAreaId { get; set; }
    public Guid? LocationTownId { get; set; }
    public Guid? OwnerId { get; set; }
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
    public int? ProductionYear { get; set; }
    public Guid UserId { get; set; }
}