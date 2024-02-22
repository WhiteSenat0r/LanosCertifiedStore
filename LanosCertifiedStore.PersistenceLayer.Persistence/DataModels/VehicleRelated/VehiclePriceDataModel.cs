using Domain.Contracts.Common;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehiclePriceDataModel : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public Guid VehicleId { get; set; }
    public VehicleDataModel Vehicle { get; set; } = null!;

    public VehiclePriceDataModel() { }
    
    public VehiclePriceDataModel(Guid vehicleId, decimal value)
    {
        VehicleId = vehicleId;
        Value = value;
    }
}
