using Domain.Contracts.Common;

namespace Persistence.DataModels;

internal sealed class VehicleImageDataModel : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CloudImageId { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsMainImage { get; set; }
    public Guid VehicleId { get; set; }
    public VehicleDataModel Vehicle { get; set; } = null!;

    public VehicleImageDataModel() { }
    
    public VehicleImageDataModel(string cloudImageId, string imageUrl, bool isMainImage)
    {
        CloudImageId = cloudImageId;
        ImageUrl = imageUrl;
        IsMainImage = isMainImage;
    }
}