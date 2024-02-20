using Application.Dtos.ImageDtos;
using Application.Dtos.VehicleDtos.Common;

namespace Application.Dtos.VehicleDtos;

public sealed record UpdateVehicleDto : ActionVehicleDto
{
    public List<ImageDto> Images { get; set; } = null!;
}