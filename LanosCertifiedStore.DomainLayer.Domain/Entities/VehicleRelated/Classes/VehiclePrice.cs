using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehiclePrice : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public Vehicle Vehicle { get; private set; } = null!;

    public VehiclePrice() { }
    public VehiclePrice(Vehicle vehicle, decimal value)
    {
        Vehicle = vehicle;
        Value = value;
    }
}
