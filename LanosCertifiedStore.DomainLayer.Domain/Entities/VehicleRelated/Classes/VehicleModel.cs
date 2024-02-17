using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public VehicleBrand Brand { get; set; } = null!;

    public VehicleModel() { }
    
    public VehicleModel(VehicleBrand brand, string name) : base(name)
    {
        Brand = brand;
    }
}