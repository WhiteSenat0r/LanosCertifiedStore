using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleImage : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string CloudImageId { get; init; } = null!;
    public string ImageUrl { get; init; } = null!;
    public bool IsMainImage { get; set; }
    public Vehicle Vehicle { get; init; } = null!;

    public VehicleImage()
    {
    }

    public VehicleImage(Vehicle? vehicle, string cloudImageId, string imageUrl)
    {
        Vehicle = vehicle;
        CloudImageId = cloudImageId;
        ImageUrl = imageUrl;
        if (vehicle?.Images.Count == 0)
            IsMainImage = true;
    }
}