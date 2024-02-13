namespace Domain.Entities.VehicleRelated.Classes.Common.Classes;

public abstract class NamedVehicleAspect
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }

    protected NamedVehicleAspect() { }
    protected NamedVehicleAspect(string name) => Name = name;
}