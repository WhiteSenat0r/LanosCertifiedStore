using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehiclePrice : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public VehiclePrice() { }
    public VehiclePrice(Guid vehicleId, decimal value)
    {
        VehicleId = vehicleId;
        Value = value;
    }
}
