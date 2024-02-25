using Domain.Contracts.Common;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleImageDataModel : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CloudImageId { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsMainImage { get; set; }
    public Guid VehicleId { get; set; }
    public VehicleDataModel Vehicle { get; set; } = null!;

    public VehicleImageDataModel() { }
    
    public VehicleImageDataModel(Guid vehicleId, string cloudImageId, string imageUrl, bool isMainImage)
    {
        VehicleId = vehicleId;
        CloudImageId = cloudImageId;
        ImageUrl = imageUrl;
        IsMainImage = isMainImage;
    }
}