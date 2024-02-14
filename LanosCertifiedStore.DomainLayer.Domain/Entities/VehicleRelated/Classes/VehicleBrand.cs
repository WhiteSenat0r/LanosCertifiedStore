using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleBrand : NamedVehicleAspect
{
    // TODO Add models collection property 
    public VehicleBrand() {}
    public VehicleBrand(string name) : base(name) {}
}
