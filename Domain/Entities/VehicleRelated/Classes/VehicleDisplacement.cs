using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleDisplacement : IEntity<Guid>
{
    public Guid Id { get; set; }
    public double Value { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    
    public VehicleDisplacement() { }

    public VehicleDisplacement(double value) => Value = value;
}
