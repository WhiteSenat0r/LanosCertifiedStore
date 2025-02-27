namespace LanosCertifiedStore.Application.Vehicles.Dtos;

public sealed record SearchVehicleDto
{
    public Guid Id { get; set; }
    public string MainImageUrl { get; set; }
    public string FullName { get; set; }
    public decimal Price { get; set; }
}