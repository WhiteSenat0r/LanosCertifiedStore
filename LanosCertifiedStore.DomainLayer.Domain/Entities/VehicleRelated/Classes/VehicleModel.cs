using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public VehicleBrand Brand { get; set; } = null!;
    public ICollection<VehicleType> AvailableTypes { get; set; } = new List<VehicleType>();

    public VehicleModel() { }
    
    public VehicleModel(VehicleBrand brand, string name, ICollection<VehicleType> availableTypes) : base(name)
    {
        Brand = brand;
        AvailableTypes = availableTypes;
    }
}