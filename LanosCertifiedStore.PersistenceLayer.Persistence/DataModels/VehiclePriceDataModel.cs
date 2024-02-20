using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts.Common;

namespace Persistence.DataModels;

internal sealed class VehiclePriceDataModel : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "decimal(10, 2)")] public decimal Value { get; set; }
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
