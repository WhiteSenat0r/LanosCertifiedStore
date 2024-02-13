using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Persistence.DataModels;

internal sealed class VehicleDataModel : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    [MaxLength(2048)] public string Description { get; set; } = null!;
    public Guid BrandId { get; set; }
    public VehicleBrandDataModel BrandDataModel { get; set; } = null!;
    public Guid ModelId { get; set; }
    public VehicleModelDataModel ModelDataModel { get; set; } = null!;
    public Guid ColorId { get; set; }
    public VehicleColorDataModel ColorDataModel { get; set; } = null!;
    public Guid TypeId { get; set; }
    public VehicleTypeDataModel TypeDataModel { get; set; } = null!;
    public Guid DisplacementId { get; set; }
    public VehicleDisplacementDataModel DisplacementDataModel { get; set; } = null!;
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
