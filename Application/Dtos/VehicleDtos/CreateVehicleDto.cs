namespace Application.Dtos.VehicleDtos;

public sealed class CreateVehicleDto
{
    public string Description { get; set; }
    public Guid BrandId { get; set; }
    public Guid ModelId { get; set; }
    public Guid ColorId { get; set; }
    public Guid TypeId { get; set; }
    public Guid DisplacementId { get; set; }
    public decimal Price { get; set; }
}