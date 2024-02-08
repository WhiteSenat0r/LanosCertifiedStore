using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes.Common.Classes;

public abstract class NamedVehicleAspect : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(64)] public string Name { get; set; }

    protected NamedVehicleAspect() { }

    protected NamedVehicleAspect(string name) => Name = name;
}