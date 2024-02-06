using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes.Common.Classes;

public abstract class NamedVehicleAspect : IEntity<Guid>
{
    public Guid Id { get; set; }
    [MaxLength(64)] public string Name { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    protected NamedVehicleAspect() { }

    protected NamedVehicleAspect(string name) => Name = name;
}