namespace Domain.Entities.VehicleRelated.Classes.Common.Classes;

public abstract class NamedVehicleTypeAspect : NamedVehicleAspect
{
    public ICollection<VehicleModel> Models { get; init; } = [];
    public ICollection<Vehicle> Vehicles { get; init; } = [];
    
    protected NamedVehicleTypeAspect() { }
    
    protected NamedVehicleTypeAspect(string name) => Name = name;
}
