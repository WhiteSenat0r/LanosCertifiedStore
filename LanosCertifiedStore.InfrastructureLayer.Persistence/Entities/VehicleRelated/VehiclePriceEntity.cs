using Domain.Contracts.Common;

namespace Persistence.Entities.VehicleRelated;

internal sealed class VehiclePriceEntity : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public Guid VehicleId { get; set; }
    public VehicleEntity Vehicle { get; set; } = null!;

    public VehiclePriceEntity() { }
    
    public VehiclePriceEntity(Guid vehicleId, decimal value)
    {
        VehicleId = vehicleId;
        Value = value;
    }
}
