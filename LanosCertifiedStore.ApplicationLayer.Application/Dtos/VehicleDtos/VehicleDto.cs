using Application.Dtos.ImageDtos;
using Application.Dtos.PriceDtos;

namespace Application.Dtos.VehicleDtos;

public record VehicleDto
{
    public Guid Id { get; init; }
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public string? Color { get; init; }
    public string? Type { get; init; }
    public double Displacement { get; init; }
    public PriceDto? Price { get; init; }
    public ImageDto? Image { get; init; }
}