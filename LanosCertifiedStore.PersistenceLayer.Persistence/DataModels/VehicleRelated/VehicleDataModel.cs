using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleDataModel : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public double Displacement { get; set; }
    public Guid BrandId { get; set; }
    public VehicleBrandDataModel Brand { get; set; } = null!;
    public Guid ModelId { get; set; }
    public VehicleModelDataModel Model { get; set; } = null!;
    public Guid ColorId { get; set; }
    public VehicleColorDataModel Color { get; set; } = null!;
    public Guid TypeId { get; set; }
    public VehicleTypeDataModel Type { get; set; } = null!;
    public ICollection<VehicleImageDataModel> Images { get; set; } = new List<VehicleImageDataModel>();
    public ICollection<VehiclePriceDataModel> Prices { get; set; } = new List<VehiclePriceDataModel>();

    public VehicleDataModel() { }
    
    public VehicleDataModel(
        Guid brandId,
        Guid modelId,
        Guid typeId,
        Guid colorId,
        decimal price,
        double displacement,
        string description)
    {
        BrandId = brandId;
        ModelId = modelId;
        TypeId = typeId;
        ColorId = colorId;
        Displacement = displacement;
        Prices.Add(new VehiclePriceDataModel(Id, price));
        Description = description;
    }
}
