using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleDisplacement : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "decimal(6, 1)")] public double Value { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    
    public VehicleDisplacement() { }

    public VehicleDisplacement(double value) => Value = value;
}
