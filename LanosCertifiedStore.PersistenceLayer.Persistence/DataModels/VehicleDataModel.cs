using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Persistence.DataModels;

internal sealed class VehicleDataModel : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(2048)] public string Description { get; set; } = null!;
    public Guid BrandId { get; set; }
    public VehicleBrandDataModel Brand { get; set; } = null!;
    public Guid ModelId { get; set; }
    public VehicleModelDataModel Model { get; set; } = null!;
    public Guid ColorId { get; set; }
    public VehicleColorDataModel Color { get; set; } = null!;
    public Guid TypeId { get; set; }
    public VehicleTypeDataModel Type { get; set; } = null!;
    public Guid DisplacementId { get; set; }
    public VehicleDisplacementDataModel Displacement { get; set; } = null!;
    public ICollection<VehiclePriceDataModel> Prices { get; set; } = new List<VehiclePriceDataModel>();

    public VehicleDataModel() { }
    public VehicleDataModel(
        Guid brandId,
        Guid modelId,
        Guid typeId,
        Guid colorId,
        Guid displacementId,
        decimal price,
        string description)
    {
        BrandId = brandId;
        ModelId = modelId;
        TypeId = typeId;
        ColorId = colorId;
        DisplacementId = displacementId;
        Prices.Add(new VehiclePriceDataModel(Id, price));
        Description = description;
    }
}
