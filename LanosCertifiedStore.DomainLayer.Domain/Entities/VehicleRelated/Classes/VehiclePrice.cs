using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehiclePrice : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public VehiclePrice() { }
    public VehiclePrice(decimal value)
    {
        Value = value;
    }
}
