using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public sealed class VehicleFilteringRequestParameters : BaseFilteringRequestParameters<Vehicle>,
    IVehicleFilteringRequestParameters
{
    public Guid? BrandId { get; set; }
    public Guid? ModelId { get; set; }
    public Guid? TypeId { get; set; }
    public Guid? EngineTypeId { get; set; }
    public Guid? DrivetrainTypeId { get; set; }
    public Guid? TransmissionTypeId { get; set; }
    public Guid? BodyTypeId { get; set; }
    public Guid? ColorId { get; set; }
    public Guid? LocationRegionAreaId { get; set; }
    public Guid? LocationAreaId { get; set; }
    public Guid? LocationTownId { get; set; }
    public Guid? OwnerId { get; set; }
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
}