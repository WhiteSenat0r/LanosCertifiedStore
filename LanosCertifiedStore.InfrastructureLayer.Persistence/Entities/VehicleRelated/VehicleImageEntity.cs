using Domain.Contracts.Common;

namespace Persistence.Entities.VehicleRelated;

internal sealed class VehicleImageEntity : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CloudImageId { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsMainImage { get; set; }
    public Guid VehicleId { get; set; }
    public VehicleEntity Vehicle { get; set; } = null!;

    public VehicleImageEntity() { }
    
    public VehicleImageEntity(Guid vehicleId, string cloudImageId, string imageUrl, bool isMainImage)
    {
        VehicleId = vehicleId;
        CloudImageId = cloudImageId;
        ImageUrl = imageUrl;
        IsMainImage = isMainImage;
    }
}