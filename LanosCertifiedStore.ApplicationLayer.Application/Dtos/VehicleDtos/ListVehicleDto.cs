using Application.Dtos.ImageDtos;
using Application.Dtos.PriceDtos;
using Domain.Contracts.Common;

namespace Application.Dtos.VehicleDtos;

public record ListVehicleDto : IIdentifiable<Guid>
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