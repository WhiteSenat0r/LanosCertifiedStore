using Application.Dtos.PriceDtos;
using Domain.Contracts.Common;

namespace Application.Dtos.VehicleDtos;

public sealed class VehicleDto : IEntity<Guid>
{
    public Guid Id { get; init; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    public double Displacement { get; set; }
    public IEnumerable<PriceDto> Prices { get; set; }
}