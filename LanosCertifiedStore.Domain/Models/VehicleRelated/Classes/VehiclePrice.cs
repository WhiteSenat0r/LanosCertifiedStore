using Domain.Contracts.Common;

namespace Domain.Models.VehicleRelated.Classes;

public sealed class VehiclePrice : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public decimal Value { get; init; }
    public DateTime IssueDate { get; init; } = DateTime.UtcNow;
    public Vehicle Vehicle { get; private set; } = null!;

    public VehiclePrice() { }
    
    public VehiclePrice(Vehicle vehicle, decimal value)
    {
        Vehicle = vehicle;
        Value = value;
    }
}
