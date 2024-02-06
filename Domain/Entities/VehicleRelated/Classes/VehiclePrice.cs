using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehiclePrice : IEntity<Guid>
{
    public Guid Id { get; set; }
    [Column(TypeName = "decimal(10, 2)")] public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    
    public VehiclePrice() { }

    public VehiclePrice(Guid vehicleId, decimal value)
    {
        VehicleId = vehicleId;
        Value = value;
    }
}
