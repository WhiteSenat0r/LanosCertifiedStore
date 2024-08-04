namespace LanosCertifiedStore.Application.Vehicles.Dtos;

public sealed record VehicleDto
{
    public Guid Id { get; set; }
    public int Mileage { get; set; }
    public double Displacement { get; set; }
    public decimal Price { get; set; }
    public string MainImageUrl { get; set; }
    public string FullName { get; set; }
    public string LocationTownName { get; set; }
    public string EngineType { get; set; }
}