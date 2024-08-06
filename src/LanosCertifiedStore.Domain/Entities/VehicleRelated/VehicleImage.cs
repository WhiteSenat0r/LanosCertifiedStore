namespace LanosCertifiedStore.Domain.Entities.VehicleRelated;

public sealed class VehicleImage
{
    public string CloudImageId { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsMainImage { get; set; }
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public VehicleImage()
    {
    }

    public VehicleImage(Guid vehicleId, string cloudImageId, string imageUrl, bool isMainImage)
    {
        VehicleId = vehicleId;
        CloudImageId = cloudImageId;
        ImageUrl = imageUrl;
        IsMainImage = isMainImage;
    }
}