using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class Vehicle : IEntity<Guid>
{
    public Guid Id { get; set; }
    [MaxLength(2048)] public string Description { get; set; }
    public Guid BrandId { get; set; }
    public VehicleBrand Brand { get; set; }
    public Guid ModelId { get; set; }
    public VehicleModel Model { get; set; }
    public Guid ColorId { get; set; }
    public VehicleColor Color { get; set; }
    public Guid TypeId { get; set; }
    public VehicleType Type { get; set; }
    public Guid DisplacementId { get; set; }
    public VehicleDisplacement Displacement { get; set; }
    public ICollection<VehiclePrice> Price { get; set; } = new List<VehiclePrice>();

    public Vehicle() { }
    
    public Vehicle(
        Guid brandId,
        Guid modelId,
        Guid typeId,
        Guid colorId,
        Guid displacementId,
        string description)
    {
        BrandId = brandId;
        ModelId = modelId;
        TypeId = typeId;
        ColorId = colorId;
        DisplacementId = displacementId;
        Description = description;
    }
}
