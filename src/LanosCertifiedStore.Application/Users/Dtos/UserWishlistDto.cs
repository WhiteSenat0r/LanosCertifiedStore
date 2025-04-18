using LanosCertifiedStore.Application.Vehicles.Dtos;

namespace LanosCertifiedStore.Application.Users.Dtos;

public sealed record UserWishlistDto
{
    public IEnumerable<VehicleDto>? Vehicles { get; set; }
}